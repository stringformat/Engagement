using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Campaign.Retrieve;

public record RetrieveCampaignQuery(Guid Id) : IRequest<Result<RetrieveCampaignResponse>>;