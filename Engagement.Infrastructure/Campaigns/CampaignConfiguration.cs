using Engagement.Domain.CampaignAggregate;

namespace Engagement.Infrastructure.Campaigns;

public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable(nameof(Campaign));
        
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
            .HasMany(x => x.Surveys)
            .WithOne();
        
        builder.Metadata.FindNavigation(nameof(Campaign.Surveys))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}