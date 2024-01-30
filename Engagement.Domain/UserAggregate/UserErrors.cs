using System.Net;
using Engagement.Common;

namespace Engagement.Domain.UserAggregate;

public static class UserErrors
{
    public static Error EmailInvalid
        => new(
            Message: $"L'email est invalide", 
            Code: ErrorType.EmailInvalid,
            StatusCode: HttpStatusCode.BadRequest);
    
    public static Error FirstNameTooLongError(int maxLength)
        => new(
            Message: $"Le prénom est trop long, il dépasse {maxLength} caractères.", 
            Code: ErrorType.FirstNameTooLong,
            StatusCode: HttpStatusCode.BadRequest);
    
    public static Error LastNameTooLongError(int maxLength)
        => new(
            Message: $"Le nom de famille est trop long, il dépasse {maxLength} caractères.", 
            Code: ErrorType.LastNameTooLong,
            StatusCode: HttpStatusCode.BadRequest);
}