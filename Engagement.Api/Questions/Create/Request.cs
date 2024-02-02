using System.Text.Json.Serialization;
using Engagement.Application.Features.Questions.Create;
using Engagement.Common.ResultPattern;

namespace Engagement.Api.Questions.Create;

[JsonPolymorphic]
[JsonDerivedType(typeof(TextRequest))]
[JsonDerivedType(typeof(RangeRequest))]
[JsonDerivedType(typeof(MultipleChoiceRequest))]
public abstract record Request(string Name, string Description, uint Order)
{
    public abstract IRequest<Result<Guid>> ToCommand(Guid surveyId);
}

public record TextRequest(string Name, string Description, uint Order) : Request(Name, Description, Order)
{
    public override IRequest<Result<Guid>> ToCommand(Guid surveyId) 
        => new CreateTextQuestionCommand(surveyId, Name, Description, Order);
}

public record RangeRequest(string Name, string Description, uint Order) : Request(Name, Description, Order)
{
    public override IRequest<Result<Guid>> ToCommand(Guid surveyId) 
        => new CreateRangeQuestionCommand(surveyId, Name, Description, Order);
}

public record MultipleChoiceRequest(string Name, string Description, uint Order, IReadOnlyCollection<MultipleChoiceRequest.Option> Options) : Request(Name, Description, Order)
{
    public record Option(uint Order, string Description);
    
    public override IRequest<Result<Guid>> ToCommand(Guid surveyId)
    {
        return new CreateMultipleChoiceQuestionCommand(
            surveyId,
            Name,
            Description,
            Order,
            Options.Select(x => new CreateMultipleChoiceQuestionCommand.Option(x.Order, x.Description)).ToList().AsReadOnly());
    }
}