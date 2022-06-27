using ConfigProection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder();
builder.Configuration.AddJsonFile("personComplex.json");
builder.Services.Configure<PersonComplex>(builder.Configuration);

var app = builder.Build();
app.Map("/Optionss", (HttpContext context, IOptions<PersonComplex> options) =>
{
    PersonComplex person = options.Value;
    return person;
});
app.Map("/Options", GetComplexPerson);



app.Run();


async Task<PersonComplex> GetComplexPerson(HttpContext context,IOptions<PersonComplex> options)
{
    PersonComplex person = options.Value;
    return person;
}