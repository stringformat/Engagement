namespace Engagement.Application.Features.Questions.Retrieve;

public record RetrieveQuestionQuery : IQuery<RetrieveQuestionRequest, Result<RetrieveQuestionResponse>>
{
    private readonly IQuestionReadRepository _repository;

    public RetrieveQuestionQuery(IQuestionReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveQuestionResponse>> Handle(RetrieveQuestionRequest request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}