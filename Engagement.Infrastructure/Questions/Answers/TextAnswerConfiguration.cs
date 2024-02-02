using Engagement.Domain.QuestionAggregate.Answers;

namespace Engagement.Infrastructure.Questions.Answers;

public class TextAnswerConfiguration : IEntityTypeConfiguration<TextAnswer>
{
    public void Configure(EntityTypeBuilder<TextAnswer> builder)
    {
        builder.Property(x => x.Value).HasColumnName($"{nameof(TextAnswer)}_{nameof(TextAnswer.Value)}");
    }
}