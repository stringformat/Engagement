using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engagement.Infrastructure.Question;

public class QuestionConfiguration : IEntityTypeConfiguration<Domain.QuestionAggregate.Question>
{
    public void Configure(EntityTypeBuilder<Domain.QuestionAggregate.Question> builder)
    {
        builder.ToTable(nameof(Domain.QuestionAggregate.Question));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.Property(x => x.Order);

        builder
            .HasMany(x => x.Answers)
            .WithOne()
            .HasForeignKey(x => x.Id);

        builder.Metadata.FindNavigation(nameof(Domain.QuestionAggregate.Question))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}