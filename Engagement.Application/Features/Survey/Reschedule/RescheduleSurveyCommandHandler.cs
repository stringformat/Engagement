using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Reschedule;

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
        var (isSurveyRetrieved, survey) = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result<RescheduleSurveyResponse>.Failure();

        var (isFailed, error) = survey.Reschedule(request.SendingDate);

        if (isFailed)
            return error;

        _repository.Update(survey);

        return new RescheduleSurveyResponse(survey.Id, survey.SendingDate);
    }
}