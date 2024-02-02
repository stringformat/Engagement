namespace Engagement.Infrastructure.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => FirstName.Create(x))
            .HasMaxLength(FirstName.MAX_LENTH);

        builder
            .Property(x => x.LastName)
            .HasConversion(x => x.Value, x => LastName.Create(x))
            .HasMaxLength(LastName.MAX_LENTH);
        
        builder
            .Property(x => x.Email)
            .HasConversion(x => x.Value, x => Email.Create(x));
    }
}