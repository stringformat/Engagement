using Engagement.Api.Campaigns.Create;
using Engagement.Api.Campaigns.List;
using Engagement.Api.Campaigns.Retrieve;
using Engagement.Api.Campaigns.Update;
using Engagement.Api.Surveys.Close;
using Engagement.Api.Surveys.Create;
using Engagement.Api.Surveys.List;
using Engagement.Api.Surveys.Open;
using Engagement.Api.Surveys.Reschedule;
using Engagement.Api.Surveys.Retrieve;
using Engagement.Api.Surveys.Update;
using Engagement.Application;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(options => options.LoggingFields = HttpLoggingFields.RequestBody | HttpLoggingFields.ResponseBody);
builder.Services.AddApplication();

var app = builder.Build();

app.UseHttpLogging();

app.MapCampaignCreate();
app.MapCampaignList();
app.MapCampaignRetrieve();
app.MapCampaignUpdate();

app.MapSurveyCreate();
app.MapSurveyList();
app.MapSurveyRetrieve();
app.MapSurveyUpdate();
app.MapSurveyOpen();
app.MapSurveyClose();
app.MapSurveyReschedule();

app.Run();