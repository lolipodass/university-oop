namespace RunProgram
{
    [Serializable]
    partial class Programer
    {
        public FIO fio
        { get; private set; }

        public Programer()
        { fio = new FIO(); }
        public Programer(string FirstName) => fio = new FIO(FirstName);
        public Programer(string FirstName, string SecondName, string LastName, int age)
        { fio = new FIO(FirstName, SecondName, LastName, age); }

    }

}