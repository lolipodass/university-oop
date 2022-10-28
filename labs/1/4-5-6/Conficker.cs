namespace RunProgram
{
    public class Conficker : Worm
    {
        public Conficker() : base("Conficker") { }
        public Conficker(string Version) : base("Conficker", Version) { }
        public override string ToString() => base.ToString();
    }
}