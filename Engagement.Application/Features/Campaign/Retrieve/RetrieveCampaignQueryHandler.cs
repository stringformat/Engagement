using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Campaign.Retrieve;

public record RetrieveCampaignQueryHandler : IRequestHandler<RetrieveCampaignQuery, Result<RetrieveCampaignResponse>>
{
    private readonly ICampaignReadRepository _repository;

    public RetrieveCampaignQueryHandler(ICampaignReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveCampaignResponse>> Handle(RetrieveCampaignQuery request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}