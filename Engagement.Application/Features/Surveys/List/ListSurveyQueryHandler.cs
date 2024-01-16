using MediatR;

namespace Engagement.Application.Features.Surveys.List;

public record ListSurveyQueryHandler : IRequestHandler<ListSurveyQuery, List<ListSurveyResponse>>
{
    private readonly ISurveyReadRepository _repository;

    public ListSurveyQueryHandler(ISurveyReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ListSurveyResponse>> Handle(ListSurveyQuery request, CancellationToken cancellationToken)
    {
        return await _repository.ListAsync(cancellationToken);
    }
}