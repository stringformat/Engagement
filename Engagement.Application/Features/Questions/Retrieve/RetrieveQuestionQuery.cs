using MediatR;

namespace Engagement.Application.Features.Questions.Retrieve;

public record RetrieveQuestionQuery(Guid Id) : IRequest<Result<RetrieveQuestionResponse>>;