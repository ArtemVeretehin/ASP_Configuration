using ConfigProection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// устанавливаем объект PersonComplex по настройкам из конфигурации
builder.Services.Configure<PersonComplex>(builder.Configuration);

var app = builder.Build();

//Привязка простых объектов
builder.Configuration.AddJsonFile("person.json");
var Artem = new person();
var Artem2 = app.Configuration.Get<person>();
builder.Configuration.Bind(Artem);
app.MapGet("/", () => $"Person1 params: name = {Artem.Name}, age = {Artem.Age}\nPerson2 params: name = {Artem2.Name}, age = {Artem2.Age}");

//Привязка сложных объектов
builder.Configuration.AddJsonFile("personComplex.json");
var Artem3 = app.Configuration.Get<PersonComplex>();
app.MapGet("/Complex", (HttpContext context) =>
{
    context.Response.ContentType = "text/html;charset=utf-8";
    context.Response.WriteAsync($"<p>name {Artem3.Name}</p><p>age {Artem3.Age}</p><p>company title {Artem3.Company?.Title}</p><p>company location {Artem3.Company?.Location}</p>");

});

//Привязка отдельных секций конфигурафии
var ArtemCompany = app.Configuration.GetSection("company").Get<Company>();
app.Map("/Company", (HttpContext context) =>
{
    context.Response.ContentType = "text/html;charset=utf-8";
    string CompanyInfo = $"<p>Company Info</p><ul><li>Title = {ArtemCompany?.Title}</li><li>Location = {ArtemCompany?.Location}</li></ul>";
    context.Response.WriteAsync(CompanyInfo);
});





app.Map("/Options", (IOptions<PersonComplex> options) =>
{
    PersonComplex person = options.Value;  // получаем переданные через Options объект Person
    return person;
});

app.Run();
