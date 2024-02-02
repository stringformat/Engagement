using Engagement.Application.Features.Questions;
using Engagement.Application.Features.Questions.List;
using Engagement.Application.Features.Questions.Retrieve;
using Engagement.Domain.QuestionAggregate;
using Engagement.Domain.QuestionAggregate.Answers;

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
                x.Answers.Select(ConvertToAnswerResponse).ToImmutableList()))
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) 
               ?? Result<RetrieveQuestionResponse>.Failure();
    }

    private static RetrieveQuestionResponse.AnswerResponse ConvertToAnswerResponse(Answer answer)
    {
        return answer switch
        {
            TextAnswer text => new RetrieveQuestionResponse.TextAnswerResponse(text.Value, text.Commentary, text.User.Id, text.Date),
            RangeAnswer range => new RetrieveQuestionResponse.RangeAnswerResponse(range.Value, range.Commentary, range.User.Id, range.Date),
            MultipleChoiceAnswer multipleChoice => new RetrieveQuestionResponse.MultipleChoiceAnswerResponse(multipleChoice.Option.Id, multipleChoice.Commentary, multipleChoice.User.Id, multipleChoice.Date),
            _ => throw new ArgumentOutOfRangeException(nameof(answer), answer, null)
        };
    }
}