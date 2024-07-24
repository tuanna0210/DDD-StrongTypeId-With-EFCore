using Demo.Domain.Abstractions;

namespace Demo.Domain.ValueObjects;

public class CustomerId : ValueObject
{
    public Guid Value { get; }
    private CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId Of(Guid value)
    {
        return new CustomerId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

//public class CustomerId : AggregateRootId<Guid>
//{
//    public override Guid Value { get; protected set; }
//    private CustomerId(Guid value)
//    {
//        Value = value;
//    }

//    public static CustomerId Of(Guid value)
//    {
//        return new CustomerId(value);
//    }

//    public override IEnumerable<object> GetEqualityComponents()
//    {
//        yield return Value;
//    }
//}
