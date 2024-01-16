namespace Engagement.Api.Questions.Reply;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}