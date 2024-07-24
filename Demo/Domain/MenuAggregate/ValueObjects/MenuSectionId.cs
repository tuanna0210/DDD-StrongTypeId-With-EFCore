using Demo.Domain.Abstractions;

namespace Demo.Domain.MenuAggregate.ValueObjects;

public class MenuSectionId : ValueObject
{
    public Guid Value { get; set; }
    private MenuSectionId(Guid value)
    {
        Value=value;
    }

    public static MenuSectionId Of(Guid value)
    {
        //Validation
        //ArgumentNullException.ThrowIfNull(value);
        //if (value == Guid.Empty)
        //{
        //    throw new DomainException("MenuSectionId cannot be empty.");
        //}
        return new MenuSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
