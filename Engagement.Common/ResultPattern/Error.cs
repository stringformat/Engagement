using System.Net;
using Microsoft.AspNetCore.Http;

namespace Engagement.Common.ResultPattern;

public record Error(string Message, Enum Code, HttpStatusCode StatusCode)
{
    public IResult ToResponse() => Results.Json(new ErrorResponse(Message, Code), statusCode: (int)StatusCode);

    private sealed record ErrorResponse(string Message, Enum Code);
}