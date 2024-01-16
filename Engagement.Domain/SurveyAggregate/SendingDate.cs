namespace Engagement.Domain.SurveyAggregate;

public record SendingDate
{
    public DateTimeOffset Value { get; }

    private SendingDate(DateTimeOffset value)
    {
        Value = value;
    }

    public static Result<SendingDate> Create(DateTimeOffset value)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        if(value == new DateTimeOffset() || value == DateTimeOffset.UnixEpoch || value < DateTimeOffset.UtcNow)
            return Result<SendingDate>.Failure();

        return new SendingDate(value);
    }
    
    public static implicit operator DateTimeOffset(SendingDate sendingDate) => sendingDate.Value;
}