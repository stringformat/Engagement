using Engagement.Application.Features.Survey;
using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.List;

public record ListQuestionQueryHandler : IRequestHandler<ListQuestionQuery, List<ListQuestionResponse>>
{
    private readonly ISurveyRepository _surveyRepository;
    private readonly IQuestionReadRepository _questionRepository;

    public ListQuestionQueryHandler(ISurveyRepository surveyRepository, IQuestionReadRepository questionRepository)
    {
        _surveyRepository = surveyRepository;
        _questionRepository = questionRepository;
    }

    public async Task<List<ListQuestionResponse>> Handle(ListQuestionQuery request, CancellationToken cancellationToken)
    {
        var surveyExist = await _surveyRepository.Exist(request.SurveyId, cancellationToken);
        
        if(!surveyExist)
            return Result<List<ListQuestionResponse>>.Failure();
        
        return await _questionRepository.ListAsync(request.SurveyId, cancellationToken);
    }
}