namespace RunProgram
{
    [Serializable]
    public class Word : TextEditor
    {
        public Word() : base("word") { }
        public Word(string version) : base("Word", version) { }
        public override string ShowName() => base.ShowName();
        public override string ToString() => base.ToString();
    }
}