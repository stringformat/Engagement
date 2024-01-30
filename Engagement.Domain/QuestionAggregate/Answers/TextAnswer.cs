using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Domain.QuestionAggregate.Answers;

public class TextAnswer : Answer
{
    public string Value { get; }

    public TextAnswer(string value, Commentary commentary, User person) 
        : base(commentary, person)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        
        Value = value;
    }
}