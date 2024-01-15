using Engagement.Common.ResultPattern;
using MediatR;

namespace Engagement.Application.Features.Question.Retrieve;

public record RetrieveQuestionQuery(Guid Id, Guid SurveyId) : IRequest<Result<RetrieveQuestionResponse>>;