using Engagement.Domain.QuestionAggregate.Answers;

namespace Engagement.Infrastructure.Questions.Answers;

public class RangeAnswerConfiguration : IEntityTypeConfiguration<RangeAnswer>
{
    public void Configure(EntityTypeBuilder<RangeAnswer> builder)
    {
        builder.Property(x => x.Value).HasColumnName($"{nameof(RangeAnswer)}_{nameof(RangeAnswer.Value)}");
    }
}