namespace RunProgram
{
    [Serializable]
    class Printer
    {
        public Type IAmPrinting(Software obj)
        {
            Console.WriteLine($"Name of object: {obj.ShowName()}");
            return obj.GetType();
        }
        public override string ToString() => $"I'm printer";

    }
}