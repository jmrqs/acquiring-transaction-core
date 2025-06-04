using Module.Accounts.Core.ValueObjects.Enums;

namespace Module.Accounts.Core.Entities
{
    public class Account
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public int AccountNumber { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal ReservedBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
