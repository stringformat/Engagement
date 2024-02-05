using System.Collections.ObjectModel;
using Engagement.Application.Features.Surveys;
using Engagement.Domain.Common;
using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;
using MediatR;

namespace Engagement.Application.Features.Questions.Create;

public record CreateMultipleChoiceQuestionCommandHandler : IRequestHandler<CreateMultipleChoiceQuestionCommand, Result<Guid>>
{
    private readonly ISurveyRepository _surveyRepository;

    public CreateMultipleChoiceQuestionCommandHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateMultipleChoiceQuestionCommand request,
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

        var options = new Collection<Option>();
        foreach (var option in request.Options)
        {
            var optionDescriptionResult = Description.Create(option.Description);

            if (!optionDescriptionResult.TryGet(out var optionDescription))
                return optionDescriptionResult.Error;

            var optionOrder = new Order(option.Order);
            
            options.Add(new Option(optionOrder, optionDescription));
        }

        var questionResult = MultipleChoiceQuestion.Create(name, description, order, request.Pillar, options);

        if (!questionResult.TryGet(out var question))
            return questionResult.Error;

        survey.AddQuestion(question);
        
        _surveyRepository.Update(survey);

        return question.Id;
    }
}