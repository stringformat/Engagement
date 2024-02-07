using Engagement.Domain.QuestionAggregate.Answers;

namespace Engagement.Domain.QuestionAggregate.Questions;

public class TextQuestion : Question
{
    public override ImmutableList<TextAnswer> Answers => [];

    public TextQuestion(Name name, Description description, Order order, Pillar pillar) 
        : base(name, description, order, pillar)
    {
    }
    
    //ORM
    private TextQuestion() { }
}