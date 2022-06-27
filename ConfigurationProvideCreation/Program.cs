using ConfigurationProvideCreation;

WebApplicationBuilder builder = WebApplication.CreateBuilder();
WebApplication app = builder.Build();

builder.Configuration.AddTextFile("config.txt");

app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();