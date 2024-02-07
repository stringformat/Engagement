using Engagement.Application.Features.Users;

namespace Engagement.Application.Features.Questions.Skip;

public record SkipQuestionCommand : ICommand<SkipQuestionRequest>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _userRepository;

    public SkipQuestionCommand(IQuestionRepository questionRepository, IUserRepository userRepository)
    {
        _questionRepository = questionRepository;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(SkipQuestionRequest request, CancellationToken cancellationToken)
    {
        var questionResult = await _questionRepository.FindAsync(request.Id, cancellationToken);
        
        if(questionResult.TryGet(out var question))
            return questionResult;

        var userResult = await _userRepository.FindAsync(request.UserId, cancellationToken);

        if (userResult.TryGet(out var user))
            return userResult;
        
        question.Skip(user);

        return Result.Success();
    }
}