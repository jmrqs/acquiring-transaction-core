using Shared.Core.Interfaces.Sagas.Contracts;
using Shared.Core.Interfaces.Sagas.ValueObjects.Enums;

namespace Shared.Core.Interfaces.Sagas
{
    public interface ICardTransactionAuthorized : IEventBase
    {
        public string? CurrentState { get; set; }
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public CardInfo CardInfo { get; set; }
        public CardType CardType { get; set; }
        public int Version { get; set; }
    }
}
