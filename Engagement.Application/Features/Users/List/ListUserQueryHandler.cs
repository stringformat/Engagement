using MediatR;

namespace Engagement.Application.Features.Users.List;

public record ListUserQueryHandler : IRequestHandler<ListUserQuery, List<ListUserResponse>>
{
    private readonly IUserReadRepository _repository;

    public ListUserQueryHandler(IUserReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ListUserResponse>> Handle(ListUserQuery request, CancellationToken cancellationToken)
    {
        return await _repository.ListAsync(cancellationToken);
    }
}