namespace Engagement.Domain.OrganizationAggregate;

public class Department
{
    public string Name { get; set; }
    
    private readonly Collection<Department> _departments = [];
    public virtual ImmutableList<Department> Departments => _departments.ToImmutableList();
    
    public void AddDepartment(Department department)
    {
        _departments.Add(department);
    }
    
    public void AddTeam(Team team)
    {
        team.AddDepartment(this);
    }
}