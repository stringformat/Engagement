using Engagement.Application.Features.Surveys;
using Engagement.Domain.Common;
using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;
using MediatR;

namespace Engagement.Application.Features.Questions.Create;

public record CreateTextQuestionCommandHandler : IRequestHandler<CreateTextQuestionCommand, Result<Guid>>
{
    private readonly ISurveyRepository _surveyRepository;

    public CreateTextQuestionCommandHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateTextQuestionCommand request,
        CancellationToken cancellationToken)
    {
        var surveyResult = await _surveyRepository.FindAsync(request.SurveyId, cancellationToken);

        if (!surveyResult.TryGet(out var survey))
            return surveyResult.Error;
        
        var nameResult = Name.Create(request.Name);
        
        if (!nameResult.TryGet(out var name))
            return nameResult.Error;
        
        var descriptionResult = Description.Create(request.Description);

        if (!descriptionResult.TryGet(out var description))
            return descriptionResult.Error;

        var order = new Order(request.Order);

        var question = new TextQuestion(name, description, order);

        survey.AddQuestion(question);
        
        _surveyRepository.Update(survey);

        return question.Id;
    }
}