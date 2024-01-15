using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Survey.Retrieve;

public record RetrieveSurveyQueryHandler : IRequestHandler<RetrieveSurveyQuery, Result<RetrieveSurveyResponse>>
{
    private readonly ISurveyReadRepository _repository;

    public RetrieveSurveyQueryHandler(ISurveyReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<RetrieveSurveyResponse>> Handle(RetrieveSurveyQuery request, CancellationToken cancellationToken)
    {
        return await _repository.RetrieveAsync(request.Id, cancellationToken);
    }
}