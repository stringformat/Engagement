namespace Engagement.Api.Questions.Reply;

public record Request(string Value, string? Commentary, Guid UserId);