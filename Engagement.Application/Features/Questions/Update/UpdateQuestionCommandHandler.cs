using Engagement.Domain.Common;

namespace Engagement.Application.Features.Questions.Update;

public record UpdateQuestionCommand : ICommand<UpdateQuestionRequest>
{
    private readonly IQuestionRepository _questionRepository;

    public UpdateQuestionCommand(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<Result> Handle(
        UpdateQuestionRequest request,
        CancellationToken cancellationToken)
    {
        var (isQuestionRetrieved, question) = await _questionRepository.FindAsync(request.Id, cancellationToken);

        if (!isQuestionRetrieved)
            return Result<Guid>.Failure();

        var (isCreatedName, name, errorName) = Name.Create(request.Name);

        if (!isCreatedName)
            return errorName;

        var (isCreatedDescription, description, errorDescription) = Description.Create(request.Description);

        if (!isCreatedDescription)
            return errorDescription;
        
        var (isFailed, error) = question.Update(name, description);
        
        if (isFailed) 
            return error;
        
        _questionRepository.Update(question);

        return Result.Success();
    }
}