namespace Engagement.Application.Features.Surveys.Retrieve;

public record RetrieveSurveyQuery : IQuery<RetrieveSurveyRequest, Result<RetrieveSurveyResponse>>
{
    private readonly ISurveyReadRepository _repository;

    public RetrieveSurveyQuery(ISurveyReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveSurveyResponse>> Handle(RetrieveSurveyRequest request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}