namespace Engagement.Application.Features.Questions;

public interface IQuestionRepository
{
    Task AddAsync(Domain.QuestionAggregate.Question entity, CancellationToken cancellationToken);
    void Update(Domain.QuestionAggregate.Question entity);
    Task<Result<Domain.QuestionAggregate.Question>> FindAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Domain.QuestionAggregate.Question>> FindAsync(HashSet<Guid> ids, CancellationToken cancellationToken);
}