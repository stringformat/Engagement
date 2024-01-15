namespace Engagement.Common.ResultPattern;

public record Error(
    string Message,
    Enum Code);