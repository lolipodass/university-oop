using System.Text.RegularExpressions;

namespace RunProgram
{
    public abstract class Software : IComparable
    {
        public string Name
        { get; private set; }
        public string Version
        { get; private set; }

        public Software()
        {
            Name = "Nameless software";
            Version = "0.0.0";
        }
        public Software(string Name)
        { this.Name = Name; Version = "0.0.1"; }
        public Software(string Name, string Version)
        {
            this.Name = Name;
            if ((new Regex(@"^\d+\.\d+\.\d+")).IsMatch(Version))
                this.Version = Version;
            else
                throw new SoftwareException("Invalid Version");
        }



        public void ChangeName(string name) => Name = name;
        public abstract string ShowName();

        public override string ToString() => "Software";

        public int CompareTo(object? o)
        {
            if (o is Software soft)
                return Name.CompareTo(soft.Name);
            else throw new ArgumentException("Некорректное значение параметра");

        }
    }
}