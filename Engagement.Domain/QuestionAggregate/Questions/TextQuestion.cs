using Engagement.Domain.QuestionAggregate.Answers;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Domain.QuestionAggregate.Questions;

public class TextQuestion : Question
{
    public override ImmutableList<TextAnswer> Answers { get; }

    public TextQuestion(Name name, Description description, Order order) 
        : base(name, description, order)
    {
    }
}