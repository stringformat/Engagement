using MediatR;

namespace Engagement.Application.Features.Surveys.Open;

public record OpenSurveyCommandHandler : IRequestHandler<OpenSurveyCommand, Result<Guid>>
{
    private readonly ISurveyRepository _repository;

    public OpenSurveyCommandHandler(ISurveyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(
        OpenSurveyCommand request,
        CancellationToken cancellationToken)
    {
        var (isSurveyRetrieved, survey) = await _repository.FindAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result<Guid>.Failure();

        var (isFailed, error) = survey.Open();

        if (isFailed)
            return error;

        _repository.Update(survey);

        return survey.Id;
    }
}