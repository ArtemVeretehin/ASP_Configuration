var builder = WebApplication.CreateBuilder(args);

//���������� ��������� ����� ���������� JSON-�����
builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "ConfigJSON.json"));
//��������� ��������� ����� ���������� XML-�����
builder.Configuration.AddXmlFile("ConfigXML.xml");
//��������� ��������� ����� ���������� INI-�����
builder.Configuration.AddIniFile("ConfigINI.ini");

//�� �� ����� ����� ��������
builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "ConfigJSON.json"))
    .AddXmlFile("ConfigXML.xml")
    .AddIniFile("ConfigINI.ini");

var app = builder.Build();

app.MapGet("/", async context =>await context.Response.WriteAsync($"{app.Configuration["name"]} - {app.Configuration["age"]} - " +
    $"{app.Configuration["person"]} - {app.Configuration["company"]} - " +
    $"{app.Configuration["Country"]} - {app.Configuration["Town"]}"));

app.Run();
