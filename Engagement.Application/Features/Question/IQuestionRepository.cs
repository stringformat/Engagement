using Engagement.Common.ResultPattern;

namespace Engagement.Application.Features.Question;

public interface IQuestionRepository
{
    Task AddAsync(Domain.QuestionAggregate.Question entity, CancellationToken cancellationToken);
    void Update(Domain.QuestionAggregate.Question entity);
    Task<Result<Domain.QuestionAggregate.Question>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}