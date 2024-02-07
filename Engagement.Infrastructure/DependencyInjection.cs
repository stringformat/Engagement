using Engagement.Application.Features.Questions;
using Engagement.Application.Features.Users;
using Engagement.Infrastructure.Campaigns;
using Engagement.Infrastructure.Questions;
using Engagement.Infrastructure.Surveys;
using Engagement.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Engagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSqlServer<EngagementContext>("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Engagement");
        
        services.TryAddTransient<ICampaignRepository, CampaignRepository>();
        services.TryAddTransient<ISurveyRepository, SurveyRepository>();
        services.TryAddTransient<IQuestionRepository, QuestionRepository>();
        services.TryAddTransient<IUserRepository, UserRepository>();

        services.TryAddTransient<ICampaignReadRepository, CampaignReadRepository>();
        services.TryAddTransient<ISurveyReadRepository, SurveyReadRepository>();
        services.TryAddTransient<IQuestionReadRepository, QuestionReadRepository>();
        services.TryAddTransient<IUserReadRepository, UserReadRepository>();

        return services;
    }
}