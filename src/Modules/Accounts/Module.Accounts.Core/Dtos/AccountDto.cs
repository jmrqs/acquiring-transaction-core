using AutoMapper;
using Module.Accounts.Core.Entities;
using Module.Accounts.Core.ValueObjects.Enums;

namespace Module.Accounts.Core.Dtos
{
    public class AccountDto(
        Guid customerId,
        Guid accountId,
        int accountNumber,
        decimal availableBalance,
        decimal reservedBalance,
        decimal creditLimit,
        AccountStatus accountStatus)
    {
        public Guid CustomerId { get; set; } = customerId;
        public Guid AccountId { get; set; } = accountId;
        public int AccountNumber { get; set; } = accountNumber;
        public decimal AvailableBalance { get; set; } = availableBalance;
        public decimal ReservedBalance { get; set; } = reservedBalance;
        public decimal CreditLimit { get; set; } = creditLimit;
        public AccountStatus AccountStatus { get; set; } = accountStatus;

        public static AccountDto Create(
            Guid customerId,
            Guid accountId,
            int accountNumber,
            decimal availableBalance,
            decimal reservedBalance,
            decimal creditLimit,
            AccountStatus accountStatus)
            => new(
                customerId,
                accountId,
                accountNumber,
                availableBalance,
                reservedBalance,
                creditLimit,
                accountStatus);
    }

    public class BranchDtoMapping : Profile
    {
        public BranchDtoMapping() => CreateMap<AccountDto, Account>().ReverseMap();
    }
}