using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engagement.Infrastructure.Survey;

public class SurveyConfiguration : IEntityTypeConfiguration<Domain.SurveyAggregate.Survey>
{
    public void Configure(EntityTypeBuilder<Domain.SurveyAggregate.Survey> builder)
    {
        builder.ToTable(nameof(Domain.SurveyAggregate.Survey));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.Property(x => x.SendingDate);
        builder.Property(x => x.Status);

        builder
            .HasMany(x => x.Questions)
            .WithOne()
            .HasForeignKey(x => x.Id);

        builder.Metadata.FindNavigation(nameof(Domain.SurveyAggregate.Survey))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}