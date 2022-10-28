namespace RunProgram
{
    public sealed partial class Programer
    {
        // override object.Equals~
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            { return false; }
            Programer prog = (Programer)obj;

            return prog.fio.FirstName == fio.FirstName;
        }

        public override int GetHashCode() => fio.FirstName.GetHashCode();

        public override string ToString() => $"Programer, Name: {fio.FirstName}";
    }
}