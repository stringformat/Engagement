namespace Engagement.Infrastructure.Common;

public class EngagementContext(DbContextOptions<EngagementContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}