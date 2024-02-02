using Engagement.Domain.QuestionAggregate.Answers;

namespace Engagement.Infrastructure.Questions.Answers;

public class MultipleChoiceAnswerConfiguration : IEntityTypeConfiguration<MultipleChoiceAnswer>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceAnswer> builder)
    {
        builder
            .HasOne(x => x.Option)
            .WithMany();
    }
}