using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Update;

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
        var (isSurveyRetrieved, survey) = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result<Guid>.Failure();

        var (isFailed, error) = survey.Update(request.Name, request.Description);
        
        if (isFailed) 
            return error;
        
        _repository.Update(survey);

        return survey.Id;
    }
}