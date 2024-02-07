using Engagement.Common.SpecificationsPattern;
using Engagement.Domain.SurveyAggregate;
using Microsoft.EntityFrameworkCore;

namespace Engagement.Application.Features.Surveys.Analyze;

public record AnalyzeSurveyQuery : IQuery<AnalyzeSurveyRequest, Result<AnalyzeSurveyResponse>>
{
    private readonly ISurveyReadRepository _repository;

    public AnalyzeSurveyQuery(ISurveyReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AnalyzeSurveyResponse>> Handle(AnalyzeSurveyRequest request, CancellationToken cancellationToken)
    {
        var spec = new QuestionsWithUserGender(request.Gender);
        
        var analyzeResult = await _repository.Analyze(spec, cancellationToken);

        if (analyzeResult.TryGet(out var analyze))
            return analyzeResult;

        return new AnalyzeSurveyResponse(analyze.ParticipationRate);
    }
}

public record QuestionsWithUserAgeBetween : Specification<Survey>
{
    public QuestionsWithUserAgeBetween(int min, int max)
    {
        Criteria = x => x.Questions.Any(q => q.Answers.Any(a => a.User.Age >= min && a.User.Age <= max));
        
        AddIncludes(s => s.Include(q => q.Questions));
    }
}

public record QuestionsWithUserGender : Specification<Survey>
{
    public QuestionsWithUserGender(Gender gender)
    {
        Criteria = x => x.Questions.Any(q => q.Answers.Any(a => a.User.Gender == gender));
        
        AddIncludes(s => s.Include(q => q.Questions));
    }
}