namespace Engagement.Common.SpecificationsPattern;

public class And<T>(ISpecification<T> left, ISpecification<T> right) : ISpecification<T>
{
    public bool IsSatisfiedBy(T entity) => left.IsSatisfiedBy(entity) && right.IsSatisfiedBy(entity);
}