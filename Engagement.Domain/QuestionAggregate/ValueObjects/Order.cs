namespace Engagement.Domain.QuestionAggregate.ValueObjects;

public record Order(uint Value)
{
    public static implicit operator uint(Order order) => order.Value;
}