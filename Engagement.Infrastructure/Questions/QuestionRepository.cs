using Engagement.Application.Features.Questions;

namespace Engagement.Infrastructure.Questions;

public class QuestionRepository(DbContext context) : RepositoryBase<Domain.QuestionAggregate.Question>(context), IQuestionRepository;