namespace RunProgram
{
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
    public struct FIO
    {
        public int Age;
        public string FirstName;
        public string SecondName;
        public string LastName;
        public FIO()
        {
            FirstName = "";
            SecondName = "";
            LastName = "";
            Age = 0;
        }
        public FIO(string FirstName)
        {
            this.FirstName = FirstName;
            SecondName = "";
            LastName = "";
            Age = 0;
        }
        public FIO(string FirstName, string SecondName, string LastName, int age)
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = LastName;
            this.Age = age;
        }
    }
}