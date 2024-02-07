using Engagement.Domain.SurveyAggregate;

namespace Engagement.Application.Features.Surveys.Reschedule;

public record RescheduleSurveyCommand : ICommand<RescheduleSurveyRequest>
{
    private readonly ISurveyRepository _repository;

    public RescheduleSurveyCommand(ISurveyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(
        RescheduleSurveyRequest request,
        CancellationToken cancellationToken)
    {
        var (isSurveyRetrieved, survey) = await _repository.FindAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result.Failure();
        
        var (isCreatedSendingDate, sendingDate, sendingDateError) = SendingDate.Create(request.SendingDate);

        if (!isCreatedSendingDate)
            return sendingDateError;

        var (isFailed, error) = survey.Reschedule(sendingDate);

        if (isFailed)
            return error;

        _repository.Update(survey);

        return Result.Success();
    }
}