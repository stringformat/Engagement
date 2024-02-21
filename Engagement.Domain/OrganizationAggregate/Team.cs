using Engagement.Common;

namespace Engagement.Domain.OrganizationAggregate;

public class Team : Entity
{
    public string Name { get; set; }
    public Department Department { get; private set; }

    private readonly Collection<User> _users = [];
    public virtual ImmutableList<User> Users => _users.ToImmutableList();

    public void AddDepartment(Department department)
    {
        Department = department;
    }
}