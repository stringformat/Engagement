using Engagement.Domain.Common;

namespace Engagement.Application.Features.Campaigns.Update;

public record UpdateCampaignCommand : ICommand<UpdateCampaignRequest>
{
    private readonly ICampaignRepository _repository;

    public UpdateCampaignCommand(ICampaignRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result> Handle(
        UpdateCampaignRequest request,
        CancellationToken cancellationToken)
    {
        var (isCampaignRetrieved, campaign) = await _repository.FindAsync(request.Id, cancellationToken);

        if (!isCampaignRetrieved)
            return Result<Guid>.Failure();
        
        var (isCreatedName, name, nameError) = Name.Create(request.Name);

        if (!isCreatedName)
            return nameError;
        
        var (isCreatedDescription, description, descriptionError) = Description.Create(request.Description);

        if (!isCreatedDescription)
            return descriptionError;

        var (isFailed, error) = campaign.Update(name, description);
        
        if (isFailed) 
            return error;
        
        _repository.Update(campaign);

        return Result.Success();
    }
}