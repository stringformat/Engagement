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
}