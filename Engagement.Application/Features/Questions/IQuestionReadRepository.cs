using Engagement.Application.Features.Questions.List;
using Engagement.Application.Features.Questions.Retrieve;

namespace Engagement.Application.Features.Questions;

public interface IQuestionReadRepository
{
    Task<List<ListQuestionResponse>> ListAsync(CancellationToken cancellationToken);
    Task<List<ListQuestionResponse>> ListAsync(Guid surveyId, CancellationToken cancellationToken);
    Task<Result<RetrieveQuestionResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken);
}