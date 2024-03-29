using Engagement.Application.Features.Users;
using Engagement.Domain.QuestionAggregate.Answers;
using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;

namespace Engagement.Application.Features.Questions.Reply;

public record ReplyQuestionCommand : ICommand<ReplyQuestionRequest>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUserRepository _userRepository;

    public ReplyQuestionCommand(IQuestionRepository questionRepository, IUserRepository userRepository)
    {
        _questionRepository = questionRepository;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(ReplyQuestionRequest request, CancellationToken cancellationToken)
    {
        var questionResult = await _questionRepository.FindAsync(request.Id, cancellationToken);

        if (!questionResult.TryGet(out var question))
            return questionResult.Error;
        
        var userResult = await _userRepository.FindAsync(request.Answer.UserId, cancellationToken);

        if (!userResult.TryGet(out var user))
            return userResult.Error;

        var (created, commentary, error) = request.Answer.Commentary is not null
            ? Commentary.Create(request.Answer.Commentary)
            : Commentary.Empty;

        if (!created)
            return error;
        
        switch (request.Answer)
        {
            case ReplyQuestionRequest.TextAnswerRequest text:
                question.Reply(new TextAnswer(text.Value, commentary, user));
                break;
            case ReplyQuestionRequest.RangeAnswerRequest range:
                var answerResult = RangeAnswer.Create(range.Value, commentary, user);
                if (!answerResult.TryGet(out var answer))
                    return answerResult.Error;
                question.Reply(answer);
                break;
            case ReplyQuestionRequest.MultipleChoiceAnswerRequest multipleChoice:
                question.Reply(CreateMultipleChoiceAnswer(multipleChoice.Value, commentary, user, (MultipleChoiceQuestion)question));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        _questionRepository.Update(question);

        return Result.Success();
    }

    private static MultipleChoiceAnswer CreateMultipleChoiceAnswer(
        Guid optionId, 
        Commentary commentary, 
        User person, 
        MultipleChoiceQuestion question)
    {
        var option = question.GetOption(optionId);
        return new MultipleChoiceAnswer(option, commentary, person);
    }
}