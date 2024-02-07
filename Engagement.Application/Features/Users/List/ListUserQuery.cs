namespace Engagement.Application.Features.Users.List;

public record ListUserQuery : IQuery<List<ListUserResponse>>
{
    private readonly IUserReadRepository _repository;

    public ListUserQuery(IUserReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ListUserResponse>> Handle(CancellationToken cancellationToken)
    {
        return await _repository.ListAsync(cancellationToken);
    }
}