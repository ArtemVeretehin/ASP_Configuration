//Получение параметров из командной строки. Важно в WebApplication.CreateBuilder передать параметр args
//Можно задавать параметры командной строки следующим образом:
//1. Через файл launchSettings.json
//2. Через командную строку при запуске проекта. Из папки проекта: dotnet run key1=value1 key2=value2
//3. Через симуляцию (см. выше)
//4. Через метод AddCommandLine

//Симуляция параметров командной строки
string[] cmdParams = { "name=Andrey", "age=56" };

var builder = WebApplication.CreateBuilder(cmdParams);
//Реальные параметры командной строки
//var builder = WebApplication.CreateBuilder(args);

//AddCommandLine
string[] AddCommandLineParams = { "City=Myski", "Height=High" };
builder.Configuration.AddCommandLine(AddCommandLineParams);



var app = builder.Build();

//Здесь выводим заданные различными способами переменные командной строки, последняя переменная - переменная окружения
app.MapGet("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]} - {appConfig["City"]} - {appConfig["Height"]} - {appConfig["NUMBER_OF_PROCESSORS"]}");

app.Run();
