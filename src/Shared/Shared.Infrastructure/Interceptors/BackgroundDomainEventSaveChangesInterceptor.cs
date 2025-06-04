using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using Shared.Core.Common;
using Shared.Core.Interfaces;
using Shared.Core.Outbox;

namespace Shared.Infrastructure.Interceptors
{
    public class BackgroundDomainEventSaveChangesInterceptor : SaveChangesInterceptor
    {
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            IGeneralDbContext generalDbContext = eventData?.Context?.GetService<IGeneralDbContext>() ??
                throw new InvalidOperationException($"Failed to get service: {typeof(IGeneralDbContext).Name}.");

            if (context == null)
                return await base.SavingChangesAsync(eventData, (InterceptionResult<int>)result, cancellationToken);

            var entities = context.ChangeTracker
               .Entries<BaseEntity>()
               .Where(e => e.Entity.BackgroundDomainEvents.Count != 0)
            .Select(e => e.Entity);

            var outboxMessages = entities
                .SelectMany(e => e.BackgroundDomainEvents)
                .Select(e => new OutboxMessage
                {
                    Id = Guid.NewGuid(),
                    OccurredOnUtc = DateTime.UtcNow,
                    Type = e.GetType().Name,
                    Content = JsonConvert.SerializeObject(e, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        TypeNameHandling = TypeNameHandling.Objects,
                        NullValueHandling = NullValueHandling.Ignore,
                    }),
                })
                .ToList();

            entities.ToList().ForEach(e => e.ClearDomainEvents());
            
            await generalDbContext.OutboxMessages.AddRangeAsync(outboxMessages, cancellationToken);

            int x = 0;
            if (outboxMessages.Count > 0 && x != 1)
            {
                x++;
                await generalDbContext.SaveChangesAsync(cancellationToken);
            }

            var res = await base.SavingChangesAsync(eventData, (InterceptionResult<int>)result, cancellationToken);
            return res;
        }
    }
}
