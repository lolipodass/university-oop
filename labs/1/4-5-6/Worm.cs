namespace RunProgram
{
    [Serializable]
    public class Worm : Virus, IOperations
    {
        public Worm() : base("Nameless Worm") { }
        public Worm(string str) : base(str) { }
        public Worm(string str, string version) : base(str, version) { }
        public override string ShowName() => base.Name;
        public override void DoIOperations() => Console.WriteLine("making some operations");
        void IOperations.DoIOperations() => Console.WriteLine("making some interfaces");
        void infect(string Name) { }

        public override string ToString() => "Worm";
    }
}