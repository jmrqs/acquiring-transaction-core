namespace Module.Transactions.Core.Dtos
{
    public record CardInfo(
        int CardTypeId,
        string CardNumber,
        string CardSecurityNumber,
        string CardHolderName,
        DateTime CardExpiration
    );
}
