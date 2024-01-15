namespace Engagement.Api.Survey.Close;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}