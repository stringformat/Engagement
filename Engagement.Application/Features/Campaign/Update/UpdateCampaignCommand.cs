using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Campaign.Update;

public record UpdateCampaignCommand(Guid Id, string Name, string Description) : IRequest<Result<Guid>>;