namespace RunProgram
{
    [Serializable]
    public abstract class Virus : Software
    {
        public Virus() : base("Nameless Virus") { }
        public Virus(string str) : base(str) { }
        public Virus(string str, string version) : base(str, version) { }
        public override string ShowName() => base.Name;
        bool isInjected() { return true; }

        public virtual void DoIOperations()
        {
            Console.WriteLine("make virus");
        }
        public override string ToString() => "Virus";
    }


}