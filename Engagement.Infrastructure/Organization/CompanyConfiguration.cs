using Engagement.Domain.OrganizationAggregate;

namespace Engagement.Infrastructure.Organization;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable(nameof(Company));
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);

        builder.Property<HierarchyId>(nameof(HierarchyId));
    }
}

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(nameof(Company));
        
        // builder.HasKey(x => x.Id);
        // builder.Property(x => x.Name);
        // builder.Property(x => x.ParentDepartment).HasConversion(x => x.Id);
        //
        // builder.Property<HierarchyId>(nameof(HierarchyId)).HasConversion(id => builder.Property(x => x.ParentDepartment).);
    }
}