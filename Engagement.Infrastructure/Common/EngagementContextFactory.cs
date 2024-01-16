using Microsoft.EntityFrameworkCore.Design;

namespace Engagement.Infrastructure.Common;

public class EngagementContextFactory : IDesignTimeDbContextFactory<EngagementContext>
{
    public EngagementContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EngagementContext>();
        optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Engagement");

        return new EngagementContext(optionsBuilder.Options);
    }
}