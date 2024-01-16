namespace Engagement.Application.Features.Surveys;

public interface ISurveyRepository
{
    Task AddAsync(Domain.SurveyAggregate.Survey entity, CancellationToken cancellationToken);
    void Update(Domain.SurveyAggregate.Survey entity);
    Task<Result<Domain.SurveyAggregate.Survey>> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Domain.SurveyAggregate.Survey>> FindAsync(HashSet<Guid> ids, CancellationToken cancellationToken);
    Task<bool> Exist(Guid id, CancellationToken cancellationToken);
}