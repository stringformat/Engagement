var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(options => options.LoggingFields = HttpLoggingFields.RequestBody | HttpLoggingFields.ResponseBody);
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

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

app.MapQuestionCreate();
app.MapQuestionList();
app.MapQuestionReply();
app.MapQuestionRetrieve();
app.MapQuestionUpdate();

app.MapUserCreate();
app.MapUserList();
app.MapUserRetrieve();

app.Run();