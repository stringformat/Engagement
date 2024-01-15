using Engagement.Application.Features.Campaign;
using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Create;

public record CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommand, Result<Guid>>
{
    private readonly ICampaignRepository _campaignRepository;

    public CreateSurveyCommandHandler(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateSurveyCommand request,
        CancellationToken cancellationToken)
    {
        var (isCampaignRetrieved, campaign) = await _campaignRepository.GetByIdAsync(request.CampaignId, cancellationToken);

        if (!isCampaignRetrieved)
            return Result<Guid>.Failure();

        var survey = new Domain.SurveyAggregate.Survey(request.Name, request.Description, request.SendingDate);
        
        campaign.AddSurvey(survey);

        _campaignRepository.Update(campaign);
        
        return survey.Id;
    }
}