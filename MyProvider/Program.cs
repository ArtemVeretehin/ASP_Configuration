using MyProvider;
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddMyTextFile("PersonConfig.txt");
var app = builder.Build();

app.MapGet("/", () => $"{app.Configuration["Name"]} - {app.Configuration["Age"]}");

app.Run();
