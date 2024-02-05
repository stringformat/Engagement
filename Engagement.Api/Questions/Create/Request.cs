using System.Text.Json.Serialization;
using Engagement.Application.Features.Questions.Create;
using Engagement.Common.ResultPattern;
using Engagement.Domain.QuestionAggregate;

namespace Engagement.Api.Questions.Create;

[JsonPolymorphic]
[JsonDerivedType(typeof(TextRequest))]
[JsonDerivedType(typeof(RangeRequest))]
[JsonDerivedType(typeof(MultipleChoiceRequest))]
public abstract record Request(string Name, string Description, uint Order, Pillar Pillar)
{
    public abstract IRequest<Result<Guid>> ToCommand(Guid surveyId);
}

public record TextRequest(string Name, string Description, uint Order, Pillar Pillar) : Request(Name, Description, Order, Pillar)
{
    public override IRequest<Result<Guid>> ToCommand(Guid surveyId) 
        => new CreateTextQuestionCommand(surveyId, Name, Description, Order, Pillar);
}

public record RangeRequest(string Name, string Description, uint Order, Pillar Pillar) : Request(Name, Description, Order, Pillar)
{
    public override IRequest<Result<Guid>> ToCommand(Guid surveyId) 
        => new CreateRangeQuestionCommand(surveyId, Name, Description, Order, Pillar);
}

public record MultipleChoiceRequest(string Name, string Description, uint Order, Pillar Pillar, IReadOnlyCollection<MultipleChoiceRequest.Option> Options) : Request(Name, Description, Order, Pillar)
{
    public record Option(uint Order, string Description);
    
    public override IRequest<Result<Guid>> ToCommand(Guid surveyId)
    {
        return new CreateMultipleChoiceQuestionCommand(
            surveyId,
            Name,
            Description,
            Order,
            Pillar,
            Options.Select(x => new CreateMultipleChoiceQuestionCommand.Option(x.Order, x.Description)).ToList().AsReadOnly());
    }
}