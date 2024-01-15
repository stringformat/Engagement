using Engagement.Common.ResultPattern;

namespace Engagement.Application.Features.Survey;

public interface ISurveyRepository
{
    Task AddAsync(Domain.SurveyAggregate.Survey entity, CancellationToken cancellationToken);
    void Update(Domain.SurveyAggregate.Survey entity);
    Task<Result<Domain.SurveyAggregate.Survey>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> Exist(Guid id, CancellationToken cancellationToken);
}