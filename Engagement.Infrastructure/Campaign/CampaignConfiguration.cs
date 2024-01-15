using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engagement.Infrastructure.Campaign;

public class CampaignConfiguration : IEntityTypeConfiguration<Domain.CampaignAggregate.Campaign>
{
    public void Configure(EntityTypeBuilder<Domain.CampaignAggregate.Campaign> builder)
    {
        builder.ToTable(nameof(Domain.CampaignAggregate.Campaign));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name);
        builder.Property(x => x.Description);

        builder
            .HasMany(x => x.Surveys)
            .WithOne()
            .HasForeignKey(x => x.Id);

        builder.Metadata.FindNavigation(nameof(Domain.CampaignAggregate.Campaign))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}