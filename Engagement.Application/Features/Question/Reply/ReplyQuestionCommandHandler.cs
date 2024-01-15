using Engagement.Application.Features.User;
using Engagement.Common.ResultPattern;
using Engagement.Domain.QuestionAggregate;
using MediatR;

namespace Engagement.Application.Features.Question.Reply;

public record ReplyQuestionCommandHandler : IRequestHandler<ReplyQuestionCommand, Result<Guid>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _userRepository;

    public ReplyQuestionCommandHandler(IQuestionRepository questionRepository, IUserRepository userRepository)
    {
        _questionRepository = questionRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<Guid>> Handle(ReplyQuestionCommand request, CancellationToken cancellationToken)
    {
        var (isRetrievedQuestion, question, questionError) = await _questionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (!isRetrievedQuestion)
            return questionError;
        
        var (isRetrievedUser, user, userError) = await _userRepository.GetByIdAsync(request.Answer.UserId, cancellationToken);

        if (!isRetrievedUser)
            return userError;
            
        question.Reply(new Answer(request.Answer.Value, request.Answer.Commentary, user));
        
        _questionRepository.Update(question);

        return question.Id;
    }
}