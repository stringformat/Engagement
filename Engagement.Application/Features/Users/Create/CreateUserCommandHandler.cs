using MediatR;

namespace Engagement.Application.Features.Users.Create;

public record CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateUserCommand request,
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

        var user = new User(firstName, lastName, email);

        await _userRepository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}