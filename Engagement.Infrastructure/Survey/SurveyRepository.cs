using Engagement.Application.Features.Survey;
using Engagement.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Engagement.Infrastructure.Survey;

public class SurveyRepository(DbContext context) : RepositoryBase<Domain.SurveyAggregate.Survey>(context), ISurveyRepository;