namespace RunProgram
{
    public class GameEngine : IOperations
    {
        public string Name
        { get; private set; }
        public GameEngine(string Name) => this.Name = Name;
        public GameEngine() => this.Name = "nameless GameEngine";

        public override string ToString()
        {
            return $"I'm Game Engine, with name {Name}";
        }
        public void DoIOperations()
        {
            Console.WriteLine("make operations");
        }
    }


    public class Word : TextEditor
    {
        public override string ToString()
        {
            return $"I'm word💩";
        }

        public override string ShowName()
        {
            return "word";
        }
    }
    public class Conficker : Worm
    {
        public override string ToString()
        {
            return $"I'm Worm, with name Conficker";
        }

        public override string ShowName()
        {
            return "Conficker";
        }
    }

    public class Minesweeper : Game
    {
        public override string ToString()
        {
            return $"I'm game, Minesweeper";
        }
        public override string ShowName()
        {
            return "Minesweeper";
        }
    }

    public sealed partial class Programer
    {
        public string FullName
        { get; private set; }

        public Programer() => FullName = "";
        public Programer(string name) => FullName = name;

        // override object.Equals~
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Programer prog = (Programer)obj;

            return prog.FullName == FullName;
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode();
        }

        public override string ToString()
        {
            return $"Programer, Name: {FullName}";
        }


    }
    class Printer
    {
        public Type IAmPrinting(Software obj)
        {
            Console.WriteLine($"Name of object: {obj.ShowName()}");
            return obj.GetType();
        }
        public override string ToString()
        {
            return $"I'm printer";
        }

    }

}