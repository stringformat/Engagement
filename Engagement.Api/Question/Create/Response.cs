namespace Engagement.Api.Question.Create;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}