//��������� ���������� �� ��������� ������. ����� � WebApplication.CreateBuilder �������� �������� args
//����� �������� ��������� ��������� ������ ��������� �������:
//1. ����� ���� launchSettings.json
//2. ����� ��������� ������ ��� ������� �������. �� ����� �������: dotnet run key1=value1 key2=value2
//3. ����� ��������� (��. ����)
//4. ����� ����� AddCommandLine

//��������� ���������� ��������� ������
string[] cmdParams = { "name=Andrey", "age=56" };

var builder = WebApplication.CreateBuilder(cmdParams);
//�������� ��������� ��������� ������
//var builder = WebApplication.CreateBuilder(args);

//AddCommandLine
string[] AddCommandLineParams = { "City=Myski", "Height=High" };
builder.Configuration.AddCommandLine(AddCommandLineParams);



var app = builder.Build();

//����� ������� �������� ���������� ��������� ���������� ��������� ������, ��������� ���������� - ���������� ���������
app.MapGet("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]} - {appConfig["City"]} - {appConfig["Height"]} - {appConfig["NUMBER_OF_PROCESSORS"]}");

app.Run();
