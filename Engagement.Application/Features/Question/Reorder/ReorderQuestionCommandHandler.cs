using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.Reorder;

public record ReorderQuestionCommandHandler : IRequestHandler<ReorderQuestionCommand, Result<ReorderQuestionResponse>>
{
    private readonly IQuestionRepository _questionRepository;

    public ReorderQuestionCommandHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Result<ReorderQuestionResponse>> Handle(ReorderQuestionCommand request, CancellationToken cancellationToken)
    {
        var (isRetrievedQuestion, question, error) = await _questionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (!isRetrievedQuestion)
            return error;
        
        question.Reorder(request.Order);
        
        _questionRepository.Update(question);

        return new ReorderQuestionResponse(question.Id, question.Order);
    }
}