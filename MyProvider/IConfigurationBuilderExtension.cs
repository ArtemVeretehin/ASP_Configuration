namespace MyProvider
{
    public static class IConfigurationBuilderExtension
    {
        public static IConfigurationBuilder AddMyTextFile(this IConfigurationBuilder configurationBuilder,string path)
        {
            var Source = new TextFileSource(path);
            return configurationBuilder.Add(Source);
        }
    }
}
