namespace Engagement.Application.Features.Users.Retrieve;

public record RetrieveUserQuery : IQuery<RetrieveUserRequest, Result<RetrieveUserResponse>>
{
    private readonly IUserReadRepository _repository;

    public RetrieveUserQuery(IUserReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveUserResponse>> Handle(RetrieveUserRequest request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}