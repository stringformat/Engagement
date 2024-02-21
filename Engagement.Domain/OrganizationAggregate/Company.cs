using Engagement.Common;

namespace Engagement.Domain.OrganizationAggregate;

public class Company : Entity
{
    public string Name { get; set; }

    public Company(string name)
    {
        Name = name;
    }
}