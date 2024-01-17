using Engagement.Application.Features.Questions;

namespace Engagement.Infrastructure.Questions;

public class QuestionRepository(EngagementContext context) : RepositoryBase<Domain.QuestionAggregate.Question>(context), IQuestionRepository;