using System.Net;
using Engagement.Common;

namespace Engagement.Domain.SurveyAggregate;

public static class SurveyErrors
{
    public static Error SendingDateIsInPast
        => new(
            Message: $"La date ne peut pas être dans le passé.", 
            Code: ErrorType.SendingDateIsInPast,
            StatusCode: HttpStatusCode.BadRequest);
}