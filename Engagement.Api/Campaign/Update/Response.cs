namespace Engagement.Api.Campaign.Update;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}