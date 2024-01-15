using Engagement.Api.Campaign.Create;
using Engagement.Api.Campaign.List;
using Engagement.Api.Campaign.Retrieve;
using Engagement.Api.Campaign.Update;
using Engagement.Api.Survey.Close;
using Engagement.Api.Survey.Create;
using Engagement.Api.Survey.List;
using Engagement.Api.Survey.Open;
using Engagement.Api.Survey.Reschedule;
using Engagement.Api.Survey.Retrieve;
using Engagement.Api.Survey.Update;
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