using Engagement.Application.Features.Users;
using Engagement.Domain.CampaignAggregate;
using Engagement.Domain.Common;
using MediatR;

namespace Engagement.Application.Features.Campaigns.Create;

public record CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Result<Guid>>
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IUserRepository _userRepository;

    public CreateCampaignCommandHandler(ICampaignRepository campaignRepository, IUserRepository userRepository)
    {
        _campaignRepository = campaignRepository;
        _userRepository = userRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateCampaignCommand request,
        CancellationToken cancellationToken)
    {
        var populations = await _userRepository.FindAsync(request.Populations, cancellationToken);
        
        var (isCreatedName, name, nameError) = Name.Create(request.Name);

        if (!isCreatedName)
            return nameError;
        
        var (isCreatedDescription, description, descriptionError) = Description.Create(request.Description);

        if (!isCreatedDescription)
            return descriptionError;
        
        var campaign = new Campaign(name, description, populations.ToHashSet());

        await _campaignRepository.AddAsync(campaign, cancellationToken);

        return campaign.Id;
    }
}