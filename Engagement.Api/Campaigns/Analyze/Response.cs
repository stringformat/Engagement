namespace Engagement.Api.Campaigns.Analyze;

public record Response(Guid Id)
{
    public static Response FromCommand(Guid id)
        => new(id);
}