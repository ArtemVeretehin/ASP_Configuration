var builder = WebApplication.CreateBuilder(args);

//Подгружаем настройки через содержимое JSON-файла
builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "ConfigJSON.json"));
//Добавляем настройки через содержимое XML-файла
builder.Configuration.AddXmlFile("ConfigXML.xml");
//Добавляем настройки через содержимое INI-файла
builder.Configuration.AddIniFile("ConfigINI.ini");

//То же самое одной командой
builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "ConfigJSON.json"))
    .AddXmlFile("ConfigXML.xml")
    .AddIniFile("ConfigINI.ini");

var app = builder.Build();

app.MapGet("/", async context =>await context.Response.WriteAsync($"{app.Configuration["name"]} - {app.Configuration["age"]} - " +
    $"{app.Configuration["person"]} - {app.Configuration["company"]} - " +
    $"{app.Configuration["Country"]} - {app.Configuration["Town"]}"));

app.Run();
