using Engagement.Application.Features.Surveys.Analyze;
using Engagement.Application.Features.Surveys.List;
using Engagement.Common.SpecificationsPattern;
using Engagement.Domain.SurveyAggregate;

namespace Engagement.Application.Features.Surveys;

public interface ISurveyReadRepository
{
    Task<List<ListSurveyResponse>> ListAsync(CancellationToken cancellationToken);
    Task<Result<RetrieveSurveyResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<AnalyzeSurveyResponse>> Analyze(Specification<Survey> specification, CancellationToken cancellationToken);
}