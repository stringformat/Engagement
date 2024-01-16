using MediatR;

namespace Engagement.Application.Features.Campaigns.List;

public record ListCampaignQuery : IRequest<List<ListCampaignResponse>>;