namespace Engagement.Application.Features.Campaigns.List;

public record ListCampaignQuery : IQuery<List<ListCampaignResponse>>
{
    private readonly ICampaignReadRepository _repository;

    public ListCampaignQuery(ICampaignReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ListCampaignResponse>> Handle(CancellationToken cancellationToken)
    {
        return await _repository.ListAsync(cancellationToken);
    }
}