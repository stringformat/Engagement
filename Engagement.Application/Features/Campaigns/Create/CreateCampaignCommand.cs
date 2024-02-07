using Engagement.Domain.CampaignAggregate;
using Engagement.Domain.Common;

namespace Engagement.Application.Features.Campaigns.Create;

public record CreateCampaignCommand : ICommandWithResult<CreateCampaignRequest>
{
    private readonly ICampaignRepository _campaignRepository;

    public CreateCampaignCommand(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }
    
    public async Task<Result<Guid>> Handle(CreateCampaignRequest request, CancellationToken cancellationToken)
    {
        var (isCreatedName, name, nameError) = Name.Create(request.Name);

        if (!isCreatedName)
            return nameError;
        
        var (isCreatedDescription, description, descriptionError) = Description.Create(request.Description);

        if (!isCreatedDescription)
            return descriptionError;
        
        var campaign = new Campaign(name, description);

        await _campaignRepository.AddAsync(campaign, cancellationToken);

        return campaign.Id;
    }
}