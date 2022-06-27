var builder = WebApplication.CreateBuilder();

var app = builder.Build();

// ��������� �������� ������������
app.Configuration["name"] = "Tom";
app.Configuration["age"] = "37";

// ����� �������� ��������� ������������ ������� ������ IConfiguration
app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();