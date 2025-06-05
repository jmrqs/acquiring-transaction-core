using MassTransit;
using Shared.Core.Interfaces.Sagas.Contracts;
using Shared.Core.Interfaces.Sagas.ValueObjects.Enums;

namespace Shared.Core.Interfaces.Sagas.States
{
    public class CardTransactionState : SagaStateMachineInstance, ISagaVersion
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public required CardInfo CardInfo { get; set; }
        public CardType CardType { get; set; }
        public int Version { get; set; }
    }
}