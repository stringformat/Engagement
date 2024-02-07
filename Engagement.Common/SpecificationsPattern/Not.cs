namespace Engagement.Common.SpecificationsPattern;

public class Not<T>(ISpecification<T> specification) : ISpecification<T>
{
    public bool IsSatisfiedBy(T entity) => !specification.IsSatisfiedBy(entity);
}