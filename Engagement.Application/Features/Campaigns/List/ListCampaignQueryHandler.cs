using MediatR;

namespace Engagement.Application.Features.Campaigns.List;

public record ListCampaignQueryHandler : IRequestHandler<ListCampaignQuery, List<ListCampaignResponse>>
{
    private readonly ICampaignReadRepository _repository;

    public ListCampaignQueryHandler(ICampaignReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ListCampaignResponse>> Handle(ListCampaignQuery request, CancellationToken cancellationToken)
    {
        return await _repository.ListAsync(cancellationToken);
    }
}