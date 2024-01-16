using Engagement.Application.Features.Surveys;
using MediatR;

namespace Engagement.Application.Features.Questions.List;

public record ListQuestionQueryHandler : IRequestHandler<ListQuestionQuery, List<ListQuestionResponse>>
{
    private readonly IQuestionReadRepository _questionRepository;

    public ListQuestionQueryHandler(ISurveyRepository surveyRepository, IQuestionReadRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<List<ListQuestionResponse>> Handle(ListQuestionQuery request, CancellationToken cancellationToken)
    {
        return await _questionRepository.ListAsync(cancellationToken);
    }
}