namespace Engagement.Api.Campaign.Create;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}