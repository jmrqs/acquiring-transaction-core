using Shared.Core.Interfaces.Sagas.ValueObjects.Enums;

namespace Shared.Core.Interfaces.Sagas.Contracts
{
    public record SubmitTransaction(
        Guid CorrelationId,
        Guid CustomerId,
        Guid AccountId,
        CardInfo CardInfo,
        CardType CardType
    );
}