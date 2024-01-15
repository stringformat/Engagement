using Engagement.Application.Features.Survey;
using Engagement.Application.Features.Survey.List;
using Engagement.Application.Features.Survey.Retrieve;
using Engagement.Common.ResultPattern;
using Engagement.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Engagement.Infrastructure.Survey;

public class SurveyReadRepository(DbContext context) : ReadRepositoryBase<Domain.SurveyAggregate.Survey>(context), ISurveyReadRepository
{
    public Task<List<ListSurveyResponse>> ListAsync(CancellationToken cancellationToken)
    {
        return Set
            .Select(x => new ListSurveyResponse(x.Id, x.Name, x.Description, x.SendingDate, x.Status))
            .ToListAsync(cancellationToken);
    }

    public async Task<Result<RetrieveSurveyResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Set
            .Select(x => new RetrieveSurveyResponse(x.Id, x.Name, x.Description, x.SendingDate, x.Status))
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) 
               ?? Result<RetrieveSurveyResponse>.Failure();
    }
}