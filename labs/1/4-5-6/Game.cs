
namespace RunProgram
{
    [Serializable]
    public enum GameType
    {
        shooter, arcade, puzzle,
        adventure, simulator, role_play, nothing
    }
    [Serializable]
    public class Game : Software, IOperations
    {
        public GameEngine gameEngine
        { get; private set; }
        public GameType Type { get; private set; }
        public Game() : base("Nameless Game")
        {
            gameEngine = new GameEngine();
            Type = GameType.nothing;
        }
        public Game(string Name) : base(Name)
        {
            gameEngine = new GameEngine();
            Type = GameType.nothing;
        }
        public Game(string Name, GameType type) : base(Name)
        {
            gameEngine = new GameEngine();
            Type = type;
        }
        public Game(string Name, GameType type, string version) : base(Name, version)
        {
            gameEngine = new GameEngine();
            Type = type;
        }
        public Game(string Name, GameType type, string version, string GameEngine) : base(Name, version)
        {
            gameEngine = new GameEngine(GameEngine);
            Type = type;
        }


        public override string ShowName() => base.Name;

        public void DoIOperations() => Console.WriteLine("making some operations");


        public override string ToString() => "Game";

    }
}