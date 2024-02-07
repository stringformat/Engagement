using System.Text.Json.Serialization;
using Engagement.Application.Features.Questions.Create;
using Engagement.Common.Cqrs;

namespace Engagement.Api.Questions.Create;

[JsonPolymorphic]
[JsonDerivedType(typeof(TextRequest))]
[JsonDerivedType(typeof(RangeRequest))]
[JsonDerivedType(typeof(MultipleChoiceRequest))]
public abstract record Request(string Name, string Description, uint Order)
{
    public abstract IRequest ToCommandRequest(Guid surveyId);
}

public record TextRequest(string Name, string Description, uint Order) : Request(Name, Description, Order)
{
    public override CreateTextQuestionRequest ToCommandRequest(Guid surveyId) 
        => new CreateTextQuestionRequest(surveyId, Name, Description, Order);
}

public record RangeRequest(string Name, string Description, uint Order) : Request(Name, Description, Order)
{
    public override CreateRangeQuestionRequest ToCommandRequest(Guid surveyId) 
        => new CreateRangeQuestionRequest(surveyId, Name, Description, Order);
}

public record MultipleChoiceRequest(string Name, string Description, uint Order, IReadOnlyCollection<MultipleChoiceRequest.Option> Options) : Request(Name, Description, Order)
{
    public record Option(uint Order, string Description);
    
    public override CreateMultipleChoiceQuestionRequest ToCommandRequest(Guid surveyId)
    {
        return new CreateMultipleChoiceQuestionRequest(
            surveyId,
            Name,
            Description,
            Order,
            Options.Select(x => new CreateMultipleChoiceQuestionRequest.Option(x.Order, x.Description)).ToList().AsReadOnly());
    }
}