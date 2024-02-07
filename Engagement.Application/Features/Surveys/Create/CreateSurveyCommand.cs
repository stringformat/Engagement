using Engagement.Application.Features.Campaigns;
using Engagement.Domain.Common;
using Engagement.Domain.SurveyAggregate;

namespace Engagement.Application.Features.Surveys.Create;

public record CreateSurveyCommand : ICommandWithResult<CreateSurveyRequest>
{
    private readonly ICampaignRepository _campaignRepository;

    public CreateSurveyCommand(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateSurveyRequest request,
        CancellationToken cancellationToken)
    {
        var (isCampaignRetrieved, campaign) = await _campaignRepository.FindAsync(request.CampaignId, cancellationToken);

        if (!isCampaignRetrieved)
            return Result<Guid>.Failure();
        
        var (isCreatedName, name, nameError) = Name.Create(request.Name);

        if (!isCreatedName)
            return nameError;
        
        var (isCreatedDescription, description, descriptionError) = Description.Create(request.Description);

        if (!isCreatedDescription)
            return descriptionError;
        
        var (isCreatedSendingDate, sendingDate, sendingDateError) = SendingDate.Create(request.SendingDate);

        if (!isCreatedSendingDate)
            return sendingDateError;

        var survey = new Survey(name, description, sendingDate);
        
        campaign.AddSurvey(survey);

        _campaignRepository.Update(campaign);

        return survey.Id;
    }
}