using Engagement.Application.Features.Campaigns.Retrieve;
using MediatR;

namespace Engagement.Application.Features.Campaigns.Analyze;

public record AnalyzeCampaignQuery(Guid Id) : IRequest<Result<RetrieveCampaignResponse>>;