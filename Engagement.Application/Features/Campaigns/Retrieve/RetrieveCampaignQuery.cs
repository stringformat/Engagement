namespace Engagement.Application.Features.Campaigns.Retrieve;

public record RetrieveCampaignQuery : IQuery<RetrieveCampaignRequest, Result<RetrieveCampaignResponse>>
{
    private readonly ICampaignReadRepository _repository;

    public RetrieveCampaignQuery(ICampaignReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveCampaignResponse>> Handle(RetrieveCampaignRequest request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}