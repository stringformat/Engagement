using MediatR;

namespace Engagement.Application.Features.Questions.Retrieve;

public record RetrieveQuestionQueryHandler : IRequestHandler<RetrieveQuestionQuery, Result<RetrieveQuestionResponse>>
{
    private readonly IQuestionReadRepository _repository;

    public RetrieveQuestionQueryHandler(IQuestionReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveQuestionResponse>> Handle(RetrieveQuestionQuery request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}