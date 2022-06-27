var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//”станавливаем значени€ настроек name и age. ѕри этом несмотр€ на то что изначально в конфигурации настроек с такими именами нет, они добавл€ютс€ автоматически.
app.Configuration["name"] = "tom";
app.Configuration["age"] = "10";

app.Run(async context =>
{
    string name = app.Configuration["name"];
    string age = app.Configuration["age"];
    await context.Response.WriteAsync($"{name} - {age}");
});
app.Run();
