namespace Engagement.Infrastructure.Surveys;

public class SurveyRepository(EngagementContext context) : RepositoryBase<Survey>(context), ISurveyRepository;