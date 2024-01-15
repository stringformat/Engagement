using Engagement.Application.Features.Question.List;
using Engagement.Application.Features.Question.Retrieve;
using Engagement.Common.ResultPattern;

namespace Engagement.Application.Features.Question;

public interface IQuestionReadRepository
{
    Task<List<ListQuestionResponse>> ListAsync(Guid surveyId, CancellationToken cancellationToken);
    Task<Result<RetrieveQuestionResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
}