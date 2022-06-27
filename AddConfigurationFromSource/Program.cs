var builder = WebApplication.CreateBuilder(args);


//Здесь заранее добавляем в конфигурацию необходимые параметры. В данном случае это набор пар "ключ-значение", но могут быть и файлы и тд
builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>() 
{
    {"name","Tom"},
    {"age","10" }
});

var app = builder.Build();
app.Run(async context => await context.Response.WriteAsync($"{app.Configuration["name"]} - {app.Configuration["age"]}"));


app.Run();
