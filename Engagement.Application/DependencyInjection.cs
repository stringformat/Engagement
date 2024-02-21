using Engagement.Application.Features.Campaigns.Create;
using Engagement.Application.Features.Campaigns.List;
using Engagement.Application.Features.Campaigns.Retrieve;
using Engagement.Application.Features.Campaigns.Update;
using Engagement.Application.Features.Questions.Create;
using Engagement.Application.Features.Questions.List;
using Engagement.Application.Features.Questions.Reorder;
using Engagement.Application.Features.Questions.Reply;
using Engagement.Application.Features.Questions.Retrieve;
using Engagement.Application.Features.Questions.Skip;
using Engagement.Application.Features.Questions.Update;
using Engagement.Application.Features.Surveys.Close;
using Engagement.Application.Features.Surveys.Create;
using Engagement.Application.Features.Surveys.List;
using Engagement.Application.Features.Surveys.Open;
using Engagement.Application.Features.Surveys.Reschedule;
using Engagement.Application.Features.Surveys.Update;
using Engagement.Application.Features.Users.Create;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Engagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        AddCampaigns(services);
        AddQuestions(services);
        AddSurveys(services);
        AddUsers(services);
        
        return services;
    }

    private static void AddCampaigns(IServiceCollection services)
    {
        services.TryAddScoped<CreateCampaignCommand>();
        services.TryAddScoped<UpdateCampaignCommand>();
        
        services.TryAddScoped<ListCampaignQuery>();
        services.TryAddScoped<RetrieveCampaignQuery>();
    }
    
    private static void AddQuestions(IServiceCollection services)
    {
        services.TryAddScoped<CreateTextQuestionCommand>();
        services.TryAddScoped<CreateRangeQuestionCommand>();
        services.TryAddScoped<CreateMultipleChoiceQuestionCommand>();
        services.TryAddScoped<SkipQuestionCommand>();
        services.TryAddScoped<ReorderQuestionCommand>();
        services.TryAddScoped<ReplyQuestionCommand>();
        services.TryAddScoped<UpdateQuestionCommand>();
        
        services.TryAddScoped<ListQuestionQuery>();
        services.TryAddScoped<RetrieveQuestionQuery>();
    }
    
    private static void AddSurveys(IServiceCollection services)
    {
        services.TryAddScoped<CreateSurveyCommand>();
        services.TryAddScoped<CloseSurveyCommand>();
        services.TryAddScoped<OpenSurveyCommand>();
        services.TryAddScoped<RescheduleSurveyCommand>();
        services.TryAddScoped<UpdateSurveyCommand>();
        
        services.TryAddScoped<ListSurveyQuery>();
        services.TryAddScoped<RetrieveSurveyQuery>();
    }
    
    private static void AddUsers(IServiceCollection services)
    {
        services.TryAddScoped<CreateUserCommand>();
        services.TryAddScoped<ListUserQuery>();
        services.TryAddScoped<RetrieveUserQuery>();
    }
}