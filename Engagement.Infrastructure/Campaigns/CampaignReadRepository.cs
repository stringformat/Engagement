using Engagement.Domain.CampaignAggregate;

namespace Engagement.Infrastructure.Campaigns;

public class CampaignReadRepository(EngagementContext context) : ReadRepositoryBase<Campaign>(context), ICampaignReadRepository
{
    public Task<List<ListCampaignResponse>> ListAsync(CancellationToken cancellationToken)
    {
        return Set
            .Select(x => new ListCampaignResponse(x.Id, x.Name, x.Description))
            .ToListAsync(cancellationToken);
    }

    public async Task<Result<RetrieveCampaignResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Set
            .Select(x => new RetrieveCampaignResponse(
                x.Id, 
                x.Name, 
                x.Description, 
                x.Surveys.Select(y => new RetrieveCampaignResponse.SurveyResponse(
                    y.Id, 
                    y.Name, 
                    y.Description, 
                    y.SendingDate)).ToImmutableList()))
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) 
               ?? Result<RetrieveCampaignResponse>.Failure();
    }
}