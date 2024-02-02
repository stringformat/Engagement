namespace Engagement.Infrastructure.Surveys;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable(nameof(Survey));
        
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
            .Property(x => x.SendingDate)
            .HasConversion(x => x.Value, x => SendingDate.Create(x));

        builder
            .HasMany(x => x.Questions)
            .WithOne();

        builder.Metadata.FindNavigation(nameof(Survey.Questions))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}