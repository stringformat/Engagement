using Engagement.Application.Features.Users;
using Engagement.Domain.QuestionAggregate;
using Engagement.Domain.QuestionAggregate.Answers;
using Engagement.Domain.QuestionAggregate.Questions;
using Engagement.Domain.QuestionAggregate.ValueObjects;
using MediatR;
using static Engagement.Domain.QuestionAggregate.Answers.RangeAnswer;

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
            case ReplyQuestionCommand.TextAnswerCommand text:
                question.Reply(new TextAnswer(text.Value, commentary, user));
                break;
            case ReplyQuestionCommand.RangeAnswerCommand range:
                var answerResult = RangeAnswer.Create(range.Value, commentary, user);
                if (!answerResult.TryGet(out var answer))
                    return answerResult.Error;
                question.Reply(answer);
                break;
            case ReplyQuestionCommand.MultipleChoiceAnswerCommand multipleChoice:
                question.Reply(CreateMultipleChoiceAnswer(multipleChoice.OptionId, commentary, user, (MultipleChoiceQuestion)question));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        _questionRepository.Update(question);

        return question.Id;
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