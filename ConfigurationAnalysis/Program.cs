var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("config.json");
builder.Configuration.AddJsonFile("ForAnalys.json");
var app = builder.Build();
//app.Run(async context => await context.Response.WriteAsync(GetSectionContent(app.Configuration.GetSection("projectConfig"))));

app.Run(async (HttpContext context) =>
{
    IEnumerable<IConfigurationSection> frameworkssections = app.Configuration.GetSection("projectConfig:frameworks:netcoreapp1.0:imports").GetChildren();
    foreach (IConfigurationSection subSection in frameworkssections)
    {
        string sssss = $"{subSection.Key} - {subSection.Value}";
    }
    IConfigurationSection config = app.Configuration.GetSection("projectConfig");
    string result = $"{config.Key}:\n";
    string ToUser = string.Concat(result, ConfigAnalysis(config));
    await context.Response.WriteAsync(ToUser);
});


string ConfigAnalysis(IConfigurationSection section, int tabCount = 1)
{
    string result = "";
    foreach (IConfigurationSection subSection in section.GetChildren())
    {
        if (subSection.Value == null)
        {
            result = string.Concat(result, new String('\t',tabCount), $"\"{subSection.Key}\":\n");
            result = string.Concat(result, ConfigAnalysis(subSection,tabCount + 1));
            //return "";
        }
        else
        {
            result = string.Concat(result, new String('\t',tabCount), $"\"{subSection.Key}\":", $"{subSection.Value};\n");
        }
    }
    return result;
}

string GetSectionContent(IConfiguration configSection)
{
    System.Text.StringBuilder contentBuilder = new();
    foreach (var section in configSection.GetChildren())
    {
        contentBuilder.Append($"\"{section.Key}\":");
        if (section.Value == null)
        {
            string subSectionContent = GetSectionContent(section);
            contentBuilder.Append($"{{\n{subSectionContent}}},\n");
        }
        else
        {
            contentBuilder.Append($"\"{section.Value}\",\n");
        }
    }
    return contentBuilder.ToString();
}






















/*
app.Map("/", async (IConfiguration configuration, HttpContext context) => 
{
    IConfiguration connectionStrings = configuration.GetSection("ConnectionStrings");
    connectionStrings.GetSection("UserContext");
    string userContext = configuration.GetConnectionString("UserContext");
    await context.Response.WriteAsync(userContext);
});
*/
app.Run();
