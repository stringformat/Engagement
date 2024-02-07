using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Application.Features.Questions.Reorder;

public record ReorderQuestionCommand : ICommand<ReorderQuestionRequest>
{
    private readonly IQuestionRepository _questionRepository;

    public ReorderQuestionCommand(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Result> Handle(ReorderQuestionRequest request, CancellationToken cancellationToken)
    {
        var (isRetrievedQuestion, question, error) = await _questionRepository.FindAsync(request.Id, cancellationToken);

        if (!isRetrievedQuestion)
            return error;

        var order = new Order(request.Order);
        
        question.Reorder(order);
        
        _questionRepository.Update(question);
        
        return Result.Success();
    }
}