using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Accounts.Core.Abstractions;
using Module.Accounts.Core.Entities;
using Shared.Core.Interfaces;
using Shared.Infrastructure.Interceptors;
using Shared.Infrastructure.Persistence;

namespace Module.Accounts.Infrastructure.Persistence
{
    public class AccountsDbContext(DbContextOptions<AccountsDbContext> options, IMediator mediator
            , ICurrentUserService currentUserService,
        BackgroundDomainEventSaveChangesInterceptor backgroundDomainEventSaveChangesInterceptor) :
        ModuleDbContext(options, currentUserService, mediator, backgroundDomainEventSaveChangesInterceptor), IAccountDbContext
    {
        protected override string Schema => "";

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>();

            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}