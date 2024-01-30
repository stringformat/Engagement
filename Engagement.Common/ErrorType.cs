namespace Engagement.Common;

public enum ErrorType
{
    Undefined = 0,
    
    NameTooLong = 1,
    DescriptionTooLong = 2,
    
    DataRequiredWhenUpdateCampaign = 3,
    
    CommentaryTooLong = 4,
    DataRequiredWhenUpdateQuestion = 5,
    ImpossibleToUpdateQuestionWithAnswers = 6,
    
    SendingDateIsInPast = 7,
    
    EmailInvalid = 8,
    FirstNameTooLong = 9,
    LastNameTooLong = 10
}