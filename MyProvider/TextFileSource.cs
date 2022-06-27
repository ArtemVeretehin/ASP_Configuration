namespace MyProvider
{
    public class TextFileSource:IConfigurationSource
    {
        public TextFileSource(string Path)
        {
            this.Path = Path;
        }
        public string Path { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new TextFileProvider(Path);
        }

    }
}
