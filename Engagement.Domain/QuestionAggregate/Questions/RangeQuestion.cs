using Engagement.Domain.QuestionAggregate.Answers;

namespace Engagement.Domain.QuestionAggregate.Questions;

public class RangeQuestion : Question
{
    public override ImmutableList<RangeAnswer> Answers => [];

    public RangeQuestion(Name name, Description description, Order order, Pillar pillar) 
        : base(name, description, order, pillar)
    {
    }
    
    //ORM
    private RangeQuestion() { }
}