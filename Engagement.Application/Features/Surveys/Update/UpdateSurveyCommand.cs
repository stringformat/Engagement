using Engagement.Domain.Common;

namespace Engagement.Application.Features.Surveys.Update;

public record UpdateSurveyCommand : ICommand<UpdateSurveyRequest>
{
    private readonly ISurveyRepository _repository;

    public UpdateSurveyCommand(ISurveyRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result> Handle(
        UpdateSurveyRequest request,
        CancellationToken cancellationToken)
    {
        var (isSurveyRetrieved, survey) = await _repository.FindAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result<Guid>.Failure();

        var (isCreatedName, name, nameError) = Name.Create(request.Name);

        if (!isCreatedName)
            return nameError;
        
        var (isCreatedDescription, description, descriptionError) = Description.Create(request.Description);

        if (!isCreatedDescription)
            return descriptionError;
        
        var (isFailed, error) = survey.Update(name, description);
        
        if (isFailed) 
            return error;
        
        _repository.Update(survey);

        return Result.Success();
    }
}