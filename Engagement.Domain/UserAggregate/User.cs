using Engagement.Common;

namespace Engagement.Domain.UserAggregate;

public class User : Entity, IAggregateRoot
{
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public Email Email { get; }
    public Gender Gender { get; set; }
    public Age Age { get; set; }
    
    public User(FirstName firstName, LastName lastName, Gender gender, Age age, Email email)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Email = email;
        Age = age;
    }

    private User()
    {
    }
}