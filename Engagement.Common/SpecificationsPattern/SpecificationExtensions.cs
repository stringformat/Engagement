namespace Engagement.Common.SpecificationsPattern;

public static class SpecificationExtensions
{
    public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right) => new And<T>(left, right);

    public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right) => new Or<T>(left, right);

    public static ISpecification<T> Not<T>(this ISpecification<T> specification) => new Not<T>(specification);
}