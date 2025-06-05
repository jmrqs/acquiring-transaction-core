namespace Shared.Core.Interfaces.Sagas
{
    public interface IEventBase
    {
        Guid CorrelationId { get; }
    }
}
