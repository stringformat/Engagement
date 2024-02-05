using Engagement.Application.Features.Surveys.Analyze;
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
            .Select(x => new RetrieveSurveyResponse(x.Id, x.Name, x.Description, x.SendingDate, x.Status))
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) 
               ?? Result<RetrieveSurveyResponse>.Failure();
    }

    public async Task<Result<AnalyzeSurveyResponse>> Analyze(Guid id)
    {
        var population = context.Set<Campaign>()
            .AsNoTracking()
            .Include(x => x.Surveys)
            .SingleOrDefaultAsync(x => x.Surveys)
        
        return Set.FirstOrDefault().
    }
}