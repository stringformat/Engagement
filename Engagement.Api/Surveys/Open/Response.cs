namespace Engagement.Api.Surveys.Open;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}