using Engagement.Application.Features.Users;

namespace Engagement.Application.Features.Questions.Ignore;

public record IgnoreQuestionCommand : ICommand<IgnoreQuestionRequest>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _userRepository;

    public IgnoreQuestionCommand(IQuestionRepository questionRepository, IUserRepository userRepository)
    {
        _questionRepository = questionRepository;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(IgnoreQuestionRequest request, CancellationToken cancellationToken)
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