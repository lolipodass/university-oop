namespace RunProgram
{

    public abstract class Software
    {
        public string Name
        { get; private set; }


        public abstract string ShowName();

        public Software() =>
            Name = "Nameless software";
        public Software(string Name) => this.Name = Name;


    }
    public abstract class TextEditor : Software
    {
        void Edit() { }
    }
    public abstract class Virus : Software
    {
        bool isInjected() { return true; }
    }
    public abstract class Worm : Virus
    {
        public void DoIOperations()
        {
            Console.WriteLine("making some operations");
        }

        void infect(string Name) { }
    }
    public abstract class Game : Software, IOperations
    {
        public GameEngine gameEngine
        { get; private set; }

        public override string ShowName()
        {
            return base.Name;
        }

        public void DoIOperations()
        {
            Console.WriteLine("making some operations");
        }

        public Game() => gameEngine = new GameEngine();
        public Game(string GameEngine) => gameEngine = new GameEngine(GameEngine);
    }

    interface IOperations
    {
        void DoIOperations();
    }
}