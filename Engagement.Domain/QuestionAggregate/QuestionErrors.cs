using System.Net;
using Engagement.Common;

namespace Engagement.Domain.QuestionAggregate;

public static class QuestionErrors
{
    public static Error CommentaryTooLongError(int maxLength)
        => new(
            Message: $"Le commentaire est trop long, il dépasse {maxLength} caractères.", 
            Code: ErrorType.CommentaryTooLong,
            StatusCode: HttpStatusCode.BadRequest);
    
    public static Error DataRequiredWhenUpdateQuestionError
        => new(
            Message: "La mise à jour d'une question requière des données.", 
            Code: ErrorType.DataRequiredWhenUpdateQuestion,
            StatusCode: HttpStatusCode.BadRequest);
    
    public static Error ImpossibleToUpdateQuestionWithAnswersError
        => new(
            Message: "La mise à jour d'une question avec des réponses n'est pas possible", 
            Code: ErrorType.ImpossibleToUpdateQuestionWithAnswers,
            StatusCode: HttpStatusCode.Conflict);
    
    public static Error RangeQuestionInvalidValueError
        => new(
            Message: "Les questions échelles doivent être entre 0 et 5", 
            Code: ErrorType.RangeQuestionInvalidValueError,
            StatusCode: HttpStatusCode.BadRequest);
    
    public static Error MultipleChoiceOptionInvalidCountError
        => new(
            Message: "Les questions à choix multiple doivent avoir entre 1 et 5 options", 
            Code: ErrorType.MultipleChoiceOptionInvalidCount,
            StatusCode: HttpStatusCode.BadRequest);
}