namespace Engagement.Api.Surveys.Create;

public record Request(string Name, string Description, DateTimeOffset SendingDate);