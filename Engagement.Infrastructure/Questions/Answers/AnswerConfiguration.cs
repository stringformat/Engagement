using Engagement.Domain.QuestionAggregate.Answers;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Infrastructure.Questions.Answers;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable(nameof(Answer));
        
        builder.HasKey(x => x.Id);
            
        builder
            .Property(x => x.Commentary)
            .HasConversion(x => x.Value, x => Commentary.Create(x))
            .HasMaxLength(Commentary.MAX_LENTH);

        builder
            .HasOne(x => x.User);
            
        builder
            .HasDiscriminator<string>("Type")
            .HasValue<TextAnswer>("text")
            .HasValue<RangeAnswer>("range")
            .HasValue<MultipleChoiceAnswer>("multiple_choice")
            .HasValue<Answer.EmptyAnswer>("empty");
        
        builder.Navigation(e => e.User).AutoInclude();
    }
}