namespace RunProgram
{
    public class Human
    {
        public string Name { get; }
        public int Age { get; set; }
        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}