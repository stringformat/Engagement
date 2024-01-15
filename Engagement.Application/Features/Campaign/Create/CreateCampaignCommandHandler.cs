using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Campaign.Create;

public record CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Result<Guid>>
{
    private readonly ICampaignRepository _repository;

    public CreateCampaignCommandHandler(ICampaignRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateCampaignCommand request,
        CancellationToken cancellationToken)
    {
        var campaign = new Domain.CampaignAggregate.Campaign(request.Name, request.Description);

        await _repository.AddAsync(campaign, cancellationToken);

        return campaign.Id;
    }
}