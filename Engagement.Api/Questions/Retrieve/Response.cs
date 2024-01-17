using Engagement.Application.Features.Questions.Retrieve;

namespace Engagement.Api.Questions.Retrieve;

public record Response(Guid Id, string Name, string Description)
{
    public static Response FromQuery(RetrieveQuestionResponse response) =>
        new(response.Id, response.Name, response.Description);
}