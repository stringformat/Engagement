using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Domain.QuestionAggregate.Questions;

public class MultipleChoiceOption(Order order, Description description) : Entity
{
    public Order Order { get; } = order;

    public Description Description { get; } = description;
}