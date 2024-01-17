using Engagement.Domain.CampaignAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engagement.Infrastructure.Campaigns;

public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable(nameof(Campaign));
        
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => Name.Create(x));

        builder
            .Property(x => x.Description)
            .HasConversion(x => x.Value, x => Description.Create(x));

        builder
            .HasMany(x => x.Surveys)
            .WithOne();
        
        builder.Metadata.FindNavigation(nameof(Campaign.Surveys))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}