using System.Net;
namespace Engagement.Common.ResultPattern;

public record Error(string Message, Enum Code, HttpStatusCode StatusCode);