namespace Engagement.Application.Features.Surveys.Create;

public record CreateSurveyRequest(Guid CampaignId, string Name, string Description, DateTimeOffset SendingDate) : IRequest;