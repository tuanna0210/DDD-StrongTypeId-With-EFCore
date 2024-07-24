using Demo.Domain.Abstractions;

namespace Demo.Domain.ValueObjects;

public class AverageRating : ValueObject
{
    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    public static AverageRating Of(double rating = 0, int numRatings = 0)
    {
        return new AverageRating(rating, numRatings);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}