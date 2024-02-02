using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Infrastructure.Questions;

public class MultipleChoiceOptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Order)
            .HasConversion(x => x.Value, x => new Order(x));

        builder
            .Property(x => x.Description)
            .HasConversion(x => x.Value, x => Description.Create(x).Value)
            .HasMaxLength(Description.MAX_LENTH);
    }
}