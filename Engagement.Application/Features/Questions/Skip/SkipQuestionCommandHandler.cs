using Engagement.Application.Features.Users;
using MediatR;

namespace Engagement.Application.Features.Questions.Skip;

public record SkipQuestionCommandHandler : IRequestHandler<SkipQuestionCommand, Result>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _userRepository;

    public SkipQuestionCommandHandler(IQuestionRepository questionRepository, IUserRepository userRepository)
    {
        _questionRepository = questionRepository;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(SkipQuestionCommand request, CancellationToken cancellationToken)
    {
        var questionResult = await _questionRepository.FindAsync(request.Id, cancellationToken);

        if (!questionResult.TryGet(out var question))
            return questionResult.Error;
        
        var userResult = await _userRepository.FindAsync(request.UserId, cancellationToken);

        if (!userResult.TryGet(out var user))
            return userResult.Error;

        question.Skip(user);
        _questionRepository.Update(question);

        return Result.Success();
    }
}