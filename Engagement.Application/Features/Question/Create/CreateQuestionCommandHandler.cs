using Engagement.Application.Features.Survey;
using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.Create;

public record CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Result<Guid>>
{
    private readonly ISurveyRepository _surveyRepository;

    public CreateQuestionCommandHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateQuestionCommand request,
        CancellationToken cancellationToken)
    {
        var (isSurveyRetrieved, survey, error) = await _surveyRepository.GetByIdAsync(request.SurveyId, cancellationToken);

        if (!isSurveyRetrieved)
            return error;
        
        var question = new Domain.QuestionAggregate.Question(request.Name, request.Description, request.Order);

        survey.AddQuestion(question);
        
        _surveyRepository.Update(survey);

        return question.Id;
    }
}