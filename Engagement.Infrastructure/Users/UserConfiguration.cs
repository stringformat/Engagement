using Engagement.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engagement.Infrastructure.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(Survey));
        
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => FirstName.Create(x).Value);

        builder
            .Property(x => x.LastName)
            .HasConversion(x => x.Value, x => LastName.Create(x).Value);

        builder
            .Property(x => x.Email)
            .HasConversion(x => x.Value, x => Email.Create(x).Value);
    }
}