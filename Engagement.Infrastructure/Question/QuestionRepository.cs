using Engagement.Application.Features.Question;
using Engagement.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Engagement.Infrastructure.Question;

public class QuestionRepository(DbContext context) : RepositoryBase<Domain.QuestionAggregate.Question>(context), IQuestionRepository;