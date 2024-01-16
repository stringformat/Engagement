using Engagement.Application.Features.Surveys.List;

namespace Engagement.Application.Features.Surveys;

public interface ISurveyReadRepository
{
    Task<List<ListSurveyResponse>> ListAsync(CancellationToken cancellationToken);
    Task<Result<RetrieveSurveyResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
}