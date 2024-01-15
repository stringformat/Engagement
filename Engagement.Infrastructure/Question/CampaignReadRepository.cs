using System.Collections.Immutable;
using Engagement.Application.Features.Campaign;
using Engagement.Application.Features.Campaign.List;
using Engagement.Application.Features.Campaign.Retrieve;
using Engagement.Common.ResultPattern;
using Engagement.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Engagement.Infrastructure.Question;

public class CampaignReadRepository(DbContext context)
    : ReadRepositoryBase<Domain.CampaignAggregate.Campaign>(context), ICampaignReadRepository
{
    public Task<List<ListCampaignResponse>> ListAsync(CancellationToken cancellationToken)
    {
        return Set
            .Select(x => new ListCampaignResponse(x.Id, x.Name, x.Description))
            .ToListAsync(cancellationToken);
    }

    public async Task<Result<RetrieveCampaignResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Set
                   .Include(x => x.Surveys)
                   .Select(x => new RetrieveCampaignResponse(x.Id, x.Name, x.Description,
                       x.Surveys.Select(y =>
                               new RetrieveCampaignResponse.Survey(y.Id, y.Name, y.Description, y.SendingDate))
                           .ToImmutableList()))
                   .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken)
               ?? Result<RetrieveCampaignResponse>.Failure();
    }
}