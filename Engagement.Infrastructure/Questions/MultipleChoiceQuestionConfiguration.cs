using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Infrastructure.Questions;

public class MultipleChoiceQuestionConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestion>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
    {
        builder
            .HasMany(x => x.Options)
            .WithOne();

        builder.Metadata.FindNavigation(nameof(MultipleChoiceQuestion.Options))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}