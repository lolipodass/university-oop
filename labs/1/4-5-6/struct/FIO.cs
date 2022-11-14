namespace RunProgram
{
    [Serializable]
    public struct FIO
    {
        public int Age;
        public string FirstName;
        public string SecondName;
        public string LastName;
        public static void Equ()
        {

        }
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