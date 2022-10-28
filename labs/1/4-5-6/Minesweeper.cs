namespace RunProgram
{
    public class Minesweeper : Game
    {
        public Minesweeper() : base("Minesweeper", GameType.puzzle) { }
        public Minesweeper(string Version) : base("Minesweeper", GameType.puzzle, Version) { }
        public override string ToString() => base.ToString();
    }

}