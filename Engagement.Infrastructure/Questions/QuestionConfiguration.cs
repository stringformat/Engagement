using Engagement.Domain.QuestionAggregate;
using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Infrastructure.Questions;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable(nameof(Question));
        
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => Name.Create(x).Value)
            .HasMaxLength(Name.MAX_LENTH);

        builder
            .Property(x => x.Description)
            .HasConversion(x => x.Value, x => Description.Create(x).Value)
            .HasMaxLength(Description.MAX_LENTH);
        
        builder
            .Property(x => x.Order)
            .HasConversion(x => x.Value, x => new Order(x));

        builder
            .HasMany(x => x.Answers)
            .WithOne();
        
        builder.HasDiscriminator<string>("Type")
            .HasValue<TextQuestion>("text")
            .HasValue<RangeQuestion>("range")
            .HasValue<MultipleChoiceQuestion>("multiple_choice");

        builder.Metadata.FindNavigation(nameof(Question.Answers))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}