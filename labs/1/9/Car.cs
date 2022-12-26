namespace RunProgram
{
    public class Car
    {
        public string name
        { get; private set; }
        public Car() => name = "";
        public Car(string name) => this.name = name;

        public override string ToString() => name;
    }
}