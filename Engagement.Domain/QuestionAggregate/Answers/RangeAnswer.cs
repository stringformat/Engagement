namespace Engagement.Domain.QuestionAggregate.Answers;

public class RangeAnswer : Answer
{
    public uint Value { get; }

    private RangeAnswer(uint value, Commentary commentary, User person) 
        : base(commentary, person)
    {
        Value = value;
    }

    //ORM
    private RangeAnswer()
    {
    }

    public static Result<RangeAnswer> Create(uint value, Commentary commentary, User person)
    {
        if (value > 5)
            return QuestionErrors.RangeQuestionInvalidValueError;
        
        return new RangeAnswer(value, commentary, person);
    }
}