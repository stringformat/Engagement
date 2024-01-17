using Engagement.Application.Features.Surveys;
using Engagement.Domain.Common;
using Engagement.Domain.QuestionAggregate;
using MediatR;

namespace Engagement.Application.Features.Questions.Create;

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
        var (isSurveyRetrieved, survey, error) = await _surveyRepository.FindAsync(request.SurveyId, cancellationToken);

        if (!isSurveyRetrieved)
            return error;
        
        var (isCreatedName, name, nameError) = Name.Create(request.Name);

        if (!isCreatedName)
            return nameError;
        
        var (isCreatedDescription, description, descriptionError) = Description.Create(request.Description);

        if (!isCreatedDescription)
            return descriptionError;
        
        var question = new Question(name, description, new Order(request.Order));

        survey.AddQuestion(question);
        
        _surveyRepository.Update(survey);

        return question.Id;
    }
}