using MediatR;

namespace Engagement.Application.Features.Surveys.Close;

public record CloseSurveyCommandHandler : IRequestHandler<CloseSurveyCommand, Result<Guid>>
{
    private readonly ISurveyRepository _repository;

    public CloseSurveyCommandHandler(ISurveyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(
        CloseSurveyCommand request,
        CancellationToken cancellationToken)
    {
        var (isSurveyRetrieved, survey) = await _repository.FindAsync(request.Id, cancellationToken);

        if (!isSurveyRetrieved)
            return Result<Guid>.Failure();

        var (isFailed, error) = survey.Close();

        if (isFailed)
            return error;

        _repository.Update(survey);

        return survey.Id;
    }
}