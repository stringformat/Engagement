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
            .HasConversion(x => x.Value, x => Name.Create(x))
            .HasMaxLength(Name.MAX_LENTH);

        builder
            .Property(x => x.Description)
            .HasConversion(x => x.Value, x => Description.Create(x))
            .HasMaxLength(Description.MAX_LENTH);
        
        builder
            .Property(x => x.Order)
            .HasConversion(x => x.Value, x => new Order(x));

        builder.OwnsMany(x => x.Answers, navigationBuilder =>
        {
            navigationBuilder.HasKey(x => x.Id);

            navigationBuilder
                .Property(x => x.Commentary)
                .HasConversion(x => x.Value, x => Commentary.Create(x))
                .HasMaxLength(Commentary.MAX_LENTH);

            navigationBuilder
                .HasOne(x => x.Person)
                .WithMany();
        });

        builder.Metadata.FindNavigation(nameof(Question.Answers))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}