using System.Text.RegularExpressions;

namespace Engagement.Domain.UserAggregate;

public partial record Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        return EmailRegex().IsMatch(value) ? 
            new Email(value) : 
            UserErrors.EmailInvalid;
    }
    
    public static EmptyEmail Empty => new();
    
    public record EmptyEmail() : Email(string.Empty);

    [GeneratedRegex("[a-zA-Z.]*@[a-zA-Z.]*\\.[a-zA-Z.]{0,3}", RegexOptions.Compiled)]
    private static partial Regex EmailRegex();
    
    public static implicit operator string(Email email) => email.Value;
}