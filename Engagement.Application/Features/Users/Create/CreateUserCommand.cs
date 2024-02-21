namespace Engagement.Application.Features.Users.Create;

public record CreateUserCommand : ICommandWithResult<CreateUserRequest>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommand(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var (isCreatedFirstName, firstName, errorFirstName) = FirstName.Create(request.FirstName);

        if (!isCreatedFirstName)
            return errorFirstName;
        
        var (isCreatedLastName, lastName, errorLastName) = LastName.Create(request.LastName);

        if (!isCreatedLastName)
            return errorLastName;
        
        var (isCreatedEmail, email, errorEmail) = Email.Create(request.Email);

        if (!isCreatedEmail)
            return errorEmail;

        var user = new User(firstName, lastName, Gender.Man, null, email);

        await _userRepository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}