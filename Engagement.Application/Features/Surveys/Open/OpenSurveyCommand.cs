namespace Engagement.Application.Features.Surveys.Open;

public record OpenSurveyCommand : ICommand<OpenSurveyRequest>
{
    private readonly ISurveyRepository _repository;

    public OpenSurveyCommand(ISurveyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(OpenSurveyRequest request, CancellationToken cancellationToken)
    {
        var (isSurveyRetrieved, survey) = await _repository.FindAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result<Guid>.Failure();

        var (isFailed, error) = survey.Open();

        if (isFailed)
            return error;

        _repository.Update(survey);

        return Result.Success();
    }
}