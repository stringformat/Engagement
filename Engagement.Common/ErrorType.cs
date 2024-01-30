namespace Engagement.Common;

public enum ErrorType
{
    Undefined,
    
    NameTooLong,
    DescriptionTooLong,
    
    DataRequiredWhenUpdateCampaign,
    
    CommentaryTooLong,
    DataRequiredWhenUpdateQuestion,
    ImpossibleToUpdateQuestionWithAnswers,
    RangeQuestionInvalidValueError,
    MultipleChoiceOptionInvalidCount,
    
    SendingDateIsInPast,
    
    EmailInvalid,
    FirstNameTooLong,
    LastNameTooLong
}