﻿using Microsoft.EntityFrameworkCore;
using Shared.Core.Outbox;

namespace Shared.Core.Interfaces
{
    public interface IGeneralDbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<OutboxMessageConsumer> OutboxMessageConsumers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}