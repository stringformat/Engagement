namespace Engagement.Api.Surveys.Update;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}