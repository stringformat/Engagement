namespace Engagement.Domain.UserAggregate;

public class User : Entity, IAggregateRoot
{
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public Email Email { get; }
    
    public User(FirstName firstName, LastName lastName, Email email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private User()
    {
    }
}