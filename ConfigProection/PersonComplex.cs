namespace ConfigProection
{
    public class PersonComplex
    {
        public string Name { get; set; } = "Undefined";
        public int Age { get; set; } = 0;
        public List<string> Languages { get; set; } = new List<string>();
        public Company? Company { get; set; }
    }

    public class Company
    {
        public string Title { get; set; } = "Undefined";
        public string Location { get; set; } = "Undefined";
    }
}
