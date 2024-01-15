using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.Update;

public record UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Result<Guid>>
{
    private readonly IQuestionRepository _questionRepository;

    public UpdateQuestionCommandHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        UpdateQuestionCommand request,
        CancellationToken cancellationToken)
    {
        var (isQuestionRetrieved, question) = await _questionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (!isQuestionRetrieved)
            return Result<Guid>.Failure();

        var (isFailed, error) = question.Update(request.Name, request.Description);
        
        if (isFailed) 
            return error;
        
        _questionRepository.Update(question);

        return question.Id;
    }
}