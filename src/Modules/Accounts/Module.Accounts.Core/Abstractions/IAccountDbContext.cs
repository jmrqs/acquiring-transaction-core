using Microsoft.EntityFrameworkCore;
using Module.Accounts.Core.Entities;

namespace Module.Accounts.Core.Abstractions
{
    public interface IAccountDbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}
