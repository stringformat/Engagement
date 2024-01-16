using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engagement.Infrastructure.Surveys;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable(nameof(Survey));
        
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => Name.Create(x).Value);
        
        builder
            .Property(x => x.Description)
            .HasConversion(x => x.Value, x => Description.Create(x).Value);
        
        builder
            .Property(x => x.SendingDate)
            .HasConversion(x => x.Value, x => SendingDate.Create(x).Value);

        builder
            .HasMany(x => x.Questions)
            .WithOne()
            .HasForeignKey(x => x.Id);

        builder.Metadata.FindNavigation(nameof(Survey))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}