namespace Engagement.Api.Surveys.Close;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}