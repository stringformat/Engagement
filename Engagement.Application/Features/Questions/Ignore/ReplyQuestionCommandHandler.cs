using Engagement.Application.Features.Users;
using Engagement.Domain.QuestionAggregate.Answers;
using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;
using MediatR;

namespace Engagement.Application.Features.Questions.Ignore;

public record IgnoreQuestionCommandHandler : IRequestHandler<IgnoreQuestionCommand, Result>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _userRepository;

    public IgnoreQuestionCommandHandler(IQuestionRepository questionRepository, IUserRepository userRepository)
    {
        _questionRepository = questionRepository;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(IgnoreQuestionCommand request, CancellationToken cancellationToken)
    {
        var questionResult = await _questionRepository.FindAsync(request.Id, cancellationToken);

        if (!questionResult.TryGet(out var question))
            return questionResult.Error;
        
        var userResult = await _userRepository.FindAsync(request.UserId, cancellationToken);

        if (!userResult.TryGet(out var user))
            return userResult.Error;

        question.Ignore(user);
        _questionRepository.Update(question);

        return Result.Success();
    }
}