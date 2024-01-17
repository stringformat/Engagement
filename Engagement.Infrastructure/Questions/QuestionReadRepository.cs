using Engagement.Application.Features.Questions;
using Engagement.Application.Features.Questions.List;
using Engagement.Application.Features.Questions.Retrieve;
using Engagement.Domain.QuestionAggregate;

namespace Engagement.Infrastructure.Questions;

public class QuestionReadRepository(EngagementContext context) : ReadRepositoryBase<Question>(context), IQuestionReadRepository
{
    public Task<List<ListQuestionResponse>> ListAsync(CancellationToken cancellationToken)
    {
        return Set
            .Select(x => new ListQuestionResponse(x.Id, x.Name, x.Description, x.Order))
            .ToListAsync(cancellationToken);
    }

    public Task<List<ListQuestionResponse>> ListAsync(Guid surveyId, CancellationToken cancellationToken)
    {
        return Set
            .Select(x => new ListQuestionResponse(x.Id, x.Name, x.Description, x.Order))
            .ToListAsync(cancellationToken);
    }

    public async Task<Result<RetrieveQuestionResponse>> RetrieveAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Set
            .Select(x => new RetrieveQuestionResponse(
                x.Id, 
                x.Name, 
                x.Description, 
                x.Order, 
                x.Answers.Select(y => new RetrieveQuestionResponse.AnswerResponse(y.Value, y.Commentary, y.Person.Id, y.Date)).ToImmutableList()))
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) 
               ?? Result<RetrieveQuestionResponse>.Failure();
    }
}