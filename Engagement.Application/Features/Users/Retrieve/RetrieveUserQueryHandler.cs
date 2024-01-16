using MediatR;

namespace Engagement.Application.Features.Users.Retrieve;

public record RetrieveUserQueryHandler : IRequestHandler<RetrieveUserQuery, Result<RetrieveUserResponse>>
{
    private readonly IUserReadRepository _repository;

    public RetrieveUserQueryHandler(IUserReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveUserResponse>> Handle(RetrieveUserQuery request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}