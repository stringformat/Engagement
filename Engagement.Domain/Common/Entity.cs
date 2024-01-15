namespace Engagement.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; } = Guid.NewGuid();
}