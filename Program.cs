using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsApp.Logging;
using SportsApp.Model;
using SportsApp.Repository;
using SportsApp.Service;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddTransient<ContextService>();
builder.Services.AddSingleton<TeamsRepositorySettings>();
builder.Services.AddScoped<TeamsRepository>();
builder.Services.AddScoped<MyLogger>();

//builder.Services.AddOptions<TeamsRepositorySettings>().Configure((parm1) => { parm1. })
//builder.Services.AddOptions<TeamsRepositorySettings>(
//    builder.Configuration.GetSection("RepositorySettings").Bind());

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
