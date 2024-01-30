using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Domain.QuestionAggregate.Answers;

public class MultipleChoiceAnswer(MultipleChoiceOption option, Commentary commentary, User person) : Answer(commentary, person)
{
    public MultipleChoiceOption Option { get; set; } = option;
}