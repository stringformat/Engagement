using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Campaign.Update;

public record UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Result<Guid>>
{
    private readonly ICampaignRepository _repository;

    public UpdateCampaignCommandHandler(ICampaignRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<Guid>> Handle(
        UpdateCampaignCommand request,
        CancellationToken cancellationToken)
    {
        var (isCampaignRetrieved, campaign) = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (!isCampaignRetrieved)
            return Result<Guid>.Failure();

        var (isFailed, error) = campaign.Update(request.Name, request.Description);
        
        if (isFailed) 
            return error;
        
        _repository.Update(campaign);

        return campaign.Id;
    }
}