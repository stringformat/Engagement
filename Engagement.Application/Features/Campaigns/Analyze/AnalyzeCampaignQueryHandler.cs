using Engagement.Application.Features.Campaigns.Retrieve;
using MediatR;

namespace Engagement.Application.Features.Campaigns.Analyze;

public record AnalyzeCampaignQueryHandler : IRequestHandler<AnalyzeCampaignQuery, Result<RetrieveCampaignResponse>>
{
    private readonly ICampaignReadRepository _repository;

    public AnalyzeCampaignQueryHandler(ICampaignReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveCampaignResponse>> Handle(AnalyzeCampaignQuery request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}