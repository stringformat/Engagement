using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Campaign.Create;

public record CreateCampaignCommand(string Name, string Description) : IRequest<Result<Guid>>;