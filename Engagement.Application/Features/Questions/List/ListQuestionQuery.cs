using Engagement.Application.Features.Surveys;

namespace Engagement.Application.Features.Questions.List;

public record ListQuestionQuery : IQuery<List<ListQuestionResponse>>
{
    private readonly IQuestionReadRepository _questionRepository;

    public ListQuestionQuery(ISurveyRepository surveyRepository, IQuestionReadRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<List<ListQuestionResponse>> Handle(CancellationToken cancellationToken)
    {
        return await _questionRepository.ListAsync(cancellationToken);
    }
}