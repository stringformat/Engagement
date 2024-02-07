namespace Engagement.Application.Features.Surveys.List;

public record ListSurveyQuery : IQuery<List<ListSurveyResponse>>
{
    private readonly ISurveyReadRepository _repository;

    public ListSurveyQuery(ISurveyReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ListSurveyResponse>> Handle(CancellationToken cancellationToken)
    {
        return await _repository.ListAsync(cancellationToken);
    }
}