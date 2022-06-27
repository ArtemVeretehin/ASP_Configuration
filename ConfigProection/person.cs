namespace ConfigProection
{
    public class person
    {
        public person()
        { }
        public person(string Name,int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        public string Name { get; set; } = "Undefined";
        public int Age { get; set; } = 0;
    }
}
