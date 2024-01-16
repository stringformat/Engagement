using Engagement.Application.Features.Users;
using Engagement.Domain.QuestionAggregate;
using MediatR;

namespace Engagement.Application.Features.Questions.Reply;

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
        var (isRetrievedQuestion, question, questionError) = await _questionRepository.FindAsync(request.Id, cancellationToken);

        if (!isRetrievedQuestion)
            return questionError;
        
        var (isRetrievedUser, user, userError) = await _userRepository.FindAsync(request.Answer.UserId, cancellationToken);

        if (!isRetrievedUser)
            return userError;

        var (isCreatedCommentary, commentary, commentaryError) = request.Answer.Commentary is not null
            ? Commentary.Create(request.Answer.Commentary)
            : Commentary.Empty;

        if (!isCreatedCommentary)
            return commentaryError;
        
        question.Reply(new Answer(request.Answer.Value, commentary, user));
        
        _questionRepository.Update(question);

        return question.Id;
    }
}