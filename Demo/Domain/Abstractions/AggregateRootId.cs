namespace Demo.Domain.Abstractions
{
    public abstract class StronglyTypedId<TId> : ValueObject
    {
        public abstract TId Value { get; protected set; }
    }
}
