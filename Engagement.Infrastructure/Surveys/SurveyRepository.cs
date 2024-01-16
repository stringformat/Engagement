namespace Engagement.Infrastructure.Surveys;

public class SurveyRepository(DbContext context) : RepositoryBase<Survey>(context), ISurveyRepository;