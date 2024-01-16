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
            .HasConversion(x => x.Value, x => Name.Create(x).Value);
        
        builder
            .Property(x => x.Description)
            .HasConversion(x => x.Value, x => Description.Create(x).Value);

        builder
            .HasMany(x => x.Surveys)
            .WithOne()
            .HasForeignKey(x => x.Id);
        
        builder
            .HasMany(x => x.Populations)
            .WithOne()
            .HasForeignKey(x => x.Id);
        
        builder.Metadata.FindNavigation(nameof(Campaign))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}