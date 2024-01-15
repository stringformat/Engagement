using Engagement.Application.Features.Survey.List;
using Engagement.Application.Features.Survey.Retrieve;
using Engagement.Common.ResultPattern;

namespace Engagement.Application.Features.User;

public interface IUserReadRepository
{
    Task<List<ListSurveyResponse>> ListAsync(CancellationToken cancellationToken);
    Task<Result<RetrieveSurveyResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
}