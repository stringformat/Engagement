namespace Engagement.Api.Question.Reply;

public record Request(string Value, string? Commentary, Guid UserId);