using Engagement.Domain.Common;

namespace Engagement.Domain.UserAggregate;

public class User : Entity, IAggregateRoot
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Email Email { get; set; }
    
    public User(string firstName, string lastName, Email email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}