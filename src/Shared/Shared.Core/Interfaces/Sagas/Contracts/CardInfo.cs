namespace Shared.Core.Interfaces.Sagas.Contracts
{
    public record CardInfo(
        int CardTypeId,
        string CardNumber,
        string CardSecurityNumber,
        string CardHolderName,
        DateTime CardExpiration
    );
}
