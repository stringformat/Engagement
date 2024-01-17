using Engagement.Application.Features.Questions.List;

namespace Engagement.Api.Questions.List;

public record Response(Guid Id, string Name, string Description, uint Order)
{
    public static Response FromQuery(ListQuestionResponse response) =>
        new(response.Id, response.Name, response.Description, response.Order);
}