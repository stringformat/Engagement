namespace Engagement.Application.Features.Surveys.Close;

public record CloseSurveyCommand : ICommand<CloseSurveyRequest>
{
    private readonly ISurveyRepository _repository;

    public CloseSurveyCommand(ISurveyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(
        CloseSurveyRequest request,
        CancellationToken cancellationToken)
    {
        var (isSurveyRetrieved, survey) = await _repository.FindAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result<Guid>.Failure();

        var (isFailed, error) = survey.Close();

        if (isFailed)
            return error;

        _repository.Update(survey);

        return Result.Success();
    }
}