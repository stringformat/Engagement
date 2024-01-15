namespace Engagement.Api.Survey.Create;

public record Request(string Name, string Description, DateTimeOffset SendingDate);