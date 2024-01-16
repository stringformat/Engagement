using Engagement.Domain.QuestionAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engagement.Infrastructure.Questions;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable(nameof(Question));
        
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => Name.Create(x).Value);
        
        builder
            .Property(x => x.Description)
            .HasConversion(x => x.Value, x => Description.Create(x).Value);
        
        builder
            .Property(x => x.Order)
            .HasConversion(x => x.Value, x => new(x));

        builder.OwnsMany(x => x.Answers, navigationBuilder =>
        {
            navigationBuilder.Property(x => x.Commentary).HasConversion(x => x.Value, x => Commentary.Create(x).Value);
        });

        builder.Metadata.FindNavigation(nameof(Question))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}