namespace Engagement.Domain.QuestionAggregate.Questions;

public class Option(Order order, Description description) : Entity
{
    public Order Order { get; } = order;

    public Description Description { get; } = description;
}