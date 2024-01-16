using MediatR;

namespace Engagement.Application.Features.Surveys.Create;

public record CreateSurveyCommand(Guid CampaignId, string Name, string Description, DateTimeOffset SendingDate) : IRequest<Result<Guid>>;