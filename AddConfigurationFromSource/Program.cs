var builder = WebApplication.CreateBuilder(args);


//����� ������� ��������� � ������������ ����������� ���������. � ������ ������ ��� ����� ��� "����-��������", �� ����� ���� � ����� � ��
builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>() 
{
    {"name","Tom"},
    {"age","10" }
});

var app = builder.Build();
app.Run(async context => await context.Response.WriteAsync($"{app.Configuration["name"]} - {app.Configuration["age"]}"));


app.Run();
