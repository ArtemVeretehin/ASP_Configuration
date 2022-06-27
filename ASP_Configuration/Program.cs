var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//������������� �������� �������� name � age. ��� ���� �������� �� �� ��� ���������� � ������������ �������� � ������ ������� ���, ��� ����������� �������������.
app.Configuration["name"] = "tom";
app.Configuration["age"] = "10";

app.Run(async context =>
{
    string name = app.Configuration["name"];
    string age = app.Configuration["age"];
    await context.Response.WriteAsync($"{name} - {age}");
});
app.Run();
