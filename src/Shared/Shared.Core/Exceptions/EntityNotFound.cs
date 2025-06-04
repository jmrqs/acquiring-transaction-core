namespace Shared.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string Entity { get; }
        public EntityNotFoundException(string entity) : base($"{entity} not found")
        {
            Entity = entity;
        }

        public EntityNotFoundException() : base("Entity not found")
        {
            Entity = string.Empty;
        }
    }
}