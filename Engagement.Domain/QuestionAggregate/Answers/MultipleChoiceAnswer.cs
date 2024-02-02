namespace Engagement.Domain.QuestionAggregate.Answers;

public class MultipleChoiceAnswer : Answer
{
    public MultipleChoiceAnswer(Option option, Commentary commentary, User person) : base(commentary, person)
    {
        Option = option;
    }

    //ORM
    private MultipleChoiceAnswer()
    {
    }

    public Option Option { get; }
}