namespace RunProgram
{
    public abstract class TextEditor : Software
    {
        public TextEditor() : base("Nameless Text Editor") { }
        public TextEditor(string str) : base(str) { }
        public TextEditor(string str, string version) : base(str, version) { }
        public override string ShowName() => base.Name;

        public override string ToString() => "Text Editor";
        void Edit() { }
    }
}