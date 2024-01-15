namespace Engagement.Api.Question.Reply;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}