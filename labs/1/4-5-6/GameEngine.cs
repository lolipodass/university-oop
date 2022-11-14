namespace RunProgram
{
    [Serializable]
    public class GameEngine : Software, IOperations
    {
        public GameEngine() : base("Nameless GameEngine") { }
        public GameEngine(string Name) : base(Name) { }
        public GameEngine(string Name, string Version) :
        base(Name, Version)
        { }
        public override string ToString() => "Game Engine";
        public override string ShowName() => Name;
        public void DoIOperations() => Console.WriteLine("make operations");
    }
}