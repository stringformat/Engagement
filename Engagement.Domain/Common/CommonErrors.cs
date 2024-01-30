using System.Net;
using Engagement.Common;

namespace Engagement.Domain.Common;

public static class CommonErrors
{
    public static Error NameTooLongError(int maxLength)
        => new(
            Message: $"Le nom est trop long, il dépasse {maxLength} caractères.", 
            Code: ErrorType.NameTooLong,
            StatusCode: HttpStatusCode.BadRequest);
    
    public static Error DescriptionTooLongError(int maxLength)
        => new(
            Message: $"La description est trop longue, elle dépasse {maxLength} caractères.", 
            Code: ErrorType.DescriptionTooLong,
            StatusCode: HttpStatusCode.BadRequest);
}