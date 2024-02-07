using Engagement.Application.Features.Surveys.Analyze;
using Engagement.Common.SpecificationsPattern;
using Engagement.Domain.CampaignAggregate;

namespace Engagement.Infrastructure.Surveys;

public class SurveyReadRepository(EngagementContext context) : ReadRepositoryBase<Survey>(context), ISurveyReadRepository
{
    public Task<List<ListSurveyResponse>> ListAsync(CancellationToken cancellationToken)
    {
        return Set
            .Select(x => new ListSurveyResponse(x.Id, x.Name, x.Description, x.SendingDate, x.Status))
            .ToListAsync(cancellationToken);
    }

    public async Task<Result<RetrieveSurveyResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Set
            .Where(x => x.Id == id)
            .Select(x => new RetrieveSurveyResponse(x.Id, x.Name, x.Description, x.SendingDate, x.Status))
            .FirstOrDefaultAsync(cancellationToken) 
               ?? Result<RetrieveSurveyResponse>.Failure();
    }

    public async Task<Result<AnalyzeSurveyResponse>> Analyze(Specification<Survey> specification, CancellationToken cancellationToken)
    {
        return await SpecificationQueryBuilder
            .GetQuery(Set, specification)
            .Select(x => new AnalyzeSurveyResponse(x.ParticipationRate))
            .FirstOrDefaultAsync(cancellationToken) ?? Result<AnalyzeSurveyResponse>.Failure();
            
    }
}