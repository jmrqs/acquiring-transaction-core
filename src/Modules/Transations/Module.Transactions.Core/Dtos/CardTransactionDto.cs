using Shared.Core.Interfaces.Sagas.ValueObjects.Enums;

namespace Module.Transactions.Core.Dtos
{
    public record CardTransactionDto(
        Guid CorrelationId,
        Guid CustomerId,
        Guid AccountId,
        CardInfo CardInfo,
        CardType CardType
    );
}