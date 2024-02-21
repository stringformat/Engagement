using Engagement.Common.ResultPattern;

namespace Engagement.Api.Extensions;

public static class ErrorExtensions
{
    public static IResult ToResponse(this Error error) => Results.Json(data: new ErrorResponse(error.Message, error.Code), statusCode: (int)error.StatusCode);

    private sealed record ErrorResponse(string Message, Enum Code);
}