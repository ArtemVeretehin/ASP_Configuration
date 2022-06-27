using ConfigProection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// ������������� ������ PersonComplex �� ���������� �� ������������
builder.Services.Configure<PersonComplex>(builder.Configuration);

var app = builder.Build();

//�������� ������� ��������
builder.Configuration.AddJsonFile("person.json");
var Artem = new person();
var Artem2 = app.Configuration.Get<person>();
builder.Configuration.Bind(Artem);
app.MapGet("/", () => $"Person1 params: name = {Artem.Name}, age = {Artem.Age}\nPerson2 params: name = {Artem2.Name}, age = {Artem2.Age}");

//�������� ������� ��������
builder.Configuration.AddJsonFile("personComplex.json");
var Artem3 = app.Configuration.Get<PersonComplex>();
app.MapGet("/Complex", (HttpContext context) =>
{
    context.Response.ContentType = "text/html;charset=utf-8";
    context.Response.WriteAsync($"<p>name {Artem3.Name}</p><p>age {Artem3.Age}</p><p>company title {Artem3.Company?.Title}</p><p>company location {Artem3.Company?.Location}</p>");

});

//�������� ��������� ������ ������������
var ArtemCompany = app.Configuration.GetSection("company").Get<Company>();
app.Map("/Company", (HttpContext context) =>
{
    context.Response.ContentType = "text/html;charset=utf-8";
    string CompanyInfo = $"<p>Company Info</p><ul><li>Title = {ArtemCompany?.Title}</li><li>Location = {ArtemCompany?.Location}</li></ul>";
    context.Response.WriteAsync(CompanyInfo);
});





app.Map("/Options", (IOptions<PersonComplex> options) =>
{
    PersonComplex person = options.Value;  // �������� ���������� ����� Options ������ Person
    return person;
});

app.Run();
