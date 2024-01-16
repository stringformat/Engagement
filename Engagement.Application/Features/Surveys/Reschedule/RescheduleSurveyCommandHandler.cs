using Engagement.Domain.SurveyAggregate;
using MediatR;

namespace Engagement.Application.Features.Surveys.Reschedule;

public record RescheduleSurveyCommandHandler : IRequestHandler<RescheduleSurveyCommand, Result<RescheduleSurveyResponse>>
{
    private readonly ISurveyRepository _repository;

    public RescheduleSurveyCommandHandler(ISurveyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RescheduleSurveyResponse>> Handle(
        RescheduleSurveyCommand request,
        CancellationToken cancellationToken)
    {
        var (isSurveyRetrieved, survey) = await _repository.FindAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result<RescheduleSurveyResponse>.Failure();
        
        var (isCreatedSendingDate, sendingDate, sendingDateError) = SendingDate.Create(request.SendingDate);

        if (!isCreatedSendingDate)
            return sendingDateError;

        var (isFailed, error) = survey.Reschedule(sendingDate);

        if (isFailed)
            return error;

        _repository.Update(survey);

        return new RescheduleSurveyResponse(survey.Id, survey.SendingDate);
    }
}