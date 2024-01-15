using MediatR;

namespace Engagement.Application.Features.Campaign.List;

public record ListCampaignQuery : IRequest<List<ListCampaignResponse>>;