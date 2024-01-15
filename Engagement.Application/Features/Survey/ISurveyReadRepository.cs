using Engagement.Application.Features.Survey.List;
using Engagement.Application.Features.Survey.Retrieve;
using Engagement.Common.ResultPattern;

namespace Engagement.Application.Features.Survey;

public interface ISurveyReadRepository
{
    Task<List<ListSurveyResponse>> ListAsync(CancellationToken cancellationToken);
    Task<Result<RetrieveSurveyResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
}