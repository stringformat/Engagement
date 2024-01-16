using Engagement.Domain.QuestionAggregate;
using MediatR;

namespace Engagement.Application.Features.Questions.Reorder;

public record ReorderQuestionCommandHandler : IRequestHandler<ReorderQuestionCommand, Result<ReorderQuestionResponse>>
{
    private readonly IQuestionRepository _questionRepository;

    public ReorderQuestionCommandHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Result<ReorderQuestionResponse>> Handle(ReorderQuestionCommand request, CancellationToken cancellationToken)
    {
        var (isRetrievedQuestion, question, error) = await _questionRepository.FindAsync(request.Id, cancellationToken);

        if (!isRetrievedQuestion)
            return error;

        var order = new Order(request.Order);
        
        question.Reorder(order);
        
        _questionRepository.Update(question);

        return new ReorderQuestionResponse(question.Id, question.Order);
    }
}