namespace Engagement.Common.SpecificationsPattern;

public interface ISpecification<in T>
{
    bool IsSatisfiedBy(T entity);
}