namespace MyProvider
{
    public class TextFileProvider: ConfigurationProvider
    {
        public string Path { get; set; }
        public TextFileProvider(string Path)
        {
            this.Path = Path;
        }
        public override void Load()
        {
            using (StreamReader Stream = new StreamReader(Path))
            {
                string? Key, Value, Line;
                Dictionary<string, string?> _data = new Dictionary<string, string?>();

                while ((Line = Stream.ReadLine()) != null)
                {
                    Key = Line;
                    Value = Stream.ReadLine();
                    _data.Add(Key, Value);
                }
                Data = _data;
            }
        }
    }
}
