using Engagement.Domain.Common;
using MediatR;

namespace Engagement.Application.Features.Surveys.Update;

public record UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommand, Result<Guid>>
{
    private readonly ISurveyRepository _repository;

    public UpdateSurveyCommandHandler(ISurveyRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<Guid>> Handle(
        UpdateSurveyCommand request,
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

        return survey.Id;
    }
}