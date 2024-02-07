using Engagement.Application.Features.Campaigns.Create;
using Engagement.Application.Features.Campaigns.List;
using Engagement.Application.Features.Campaigns.Retrieve;
using Engagement.Application.Features.Campaigns.Update;
using Engagement.Application.Features.Questions.Create;
using Engagement.Application.Features.Questions.Ignore;
using Engagement.Application.Features.Questions.List;
using Engagement.Application.Features.Questions.Reorder;
using Engagement.Application.Features.Questions.Reply;
using Engagement.Application.Features.Questions.Retrieve;
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
        services.TryAddScoped<ICommandWithResult<CreateCampaignRequest>, CreateCampaignCommand>();
        services.TryAddScoped<ICommand<UpdateCampaignRequest>, UpdateCampaignCommand>();
        
        services.TryAddScoped<IQuery<List<ListCampaignResponse>>, ListCampaignQuery>();
        services.TryAddScoped<IQuery<RetrieveCampaignRequest, Result<RetrieveCampaignResponse>>, RetrieveCampaignQuery>();
    }
    
    private static void AddQuestions(IServiceCollection services)
    {
        services.TryAddScoped<ICommandWithResult<CreateTextQuestionRequest>, CreateTextQuestionCommand>();
        services.TryAddScoped<ICommandWithResult<CreateRangeQuestionRequest>, CreateRangeQuestionCommand>();
        services.TryAddScoped<ICommandWithResult<CreateMultipleChoiceQuestionRequest>, CreateMultipleChoiceQuestionCommand>();
        services.TryAddScoped<ICommand<IgnoreQuestionRequest>, IgnoreQuestionCommand>();
        services.TryAddScoped<ICommand<ReorderQuestionRequest>, ReorderQuestionCommand>();
        services.TryAddScoped<ICommand<ReplyQuestionRequest>, ReplyQuestionCommand>();
        services.TryAddScoped<ICommand<UpdateQuestionRequest>, UpdateQuestionCommand>();
        
        services.TryAddScoped<IQuery<List<ListQuestionResponse>>, ListQuestionQuery>();
        services.TryAddScoped<IQuery<RetrieveQuestionRequest, Result<RetrieveQuestionResponse>>, RetrieveQuestionQuery>();
    }
    
    private static void AddSurveys(IServiceCollection services)
    {
        services.TryAddScoped<ICommandWithResult<CreateSurveyRequest>, CreateSurveyCommand>();
        services.TryAddScoped<ICommand<CloseSurveyRequest>, CloseSurveyCommand>();
        services.TryAddScoped<ICommand<OpenSurveyRequest>, OpenSurveyCommand>();
        services.TryAddScoped<ICommand<RescheduleSurveyRequest>, RescheduleSurveyCommand>();
        services.TryAddScoped<ICommand<UpdateSurveyRequest>, UpdateSurveyCommand>();
        
        services.TryAddScoped<IQuery<List<ListSurveyResponse>>, ListSurveyQuery>();
        services.TryAddScoped<IQuery<RetrieveSurveyRequest, Result<RetrieveSurveyResponse>>, RetrieveSurveyQuery>();
    }
    
    private static void AddUsers(IServiceCollection services)
    {
        services.TryAddScoped<ICommandWithResult<CreateUserRequest>, CreateUserCommand>();
        
        services.TryAddScoped<IQuery<List<ListUserResponse>>, ListUserQuery>();
        services.TryAddScoped<IQuery<RetrieveUserRequest, Result<RetrieveUserResponse>>, RetrieveUserQuery>();
    }
}