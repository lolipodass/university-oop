namespace RunProgram
{
    public class Subscriber
    {
        public int Sum
        { get; private set; }
        public void Showing(int number)
        { Console.WriteLine(number); }

        public void Save(int number)
        { Sum += number; }
    }

}