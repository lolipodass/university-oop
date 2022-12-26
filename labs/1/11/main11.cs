namespace RunProgram11
{
    public class Program
    {
        public int some
        { get; private set; }
        public int i;

        public static void Main()
        {
            Console.WriteLine("Name");
            Reflector<Program>.Name();
            Console.WriteLine("\nPublic Methods");
            Reflector<Program>.PublicMethods();
            Console.WriteLine("\nHave constructor");
            Reflector<Program>.HaveConstructor();
            Console.WriteLine("\nHave fields");
            Reflector<Program>.Fields();
            Console.WriteLine("\nMethods with param");
            Reflector<Program>.MethodsWithParam("some".GetType());
            Reflector<Program>.MethodsWithParam(typeof(System.Object));
            Reflector<Program>.MethodsWithParam(typeof(int));
            Console.WriteLine("\n Invoke");
            Reflector<Program>.MyInvoke("Some", "some");
            Console.WriteLine("\n Create");

            Reflector<Program>.Create("Program", param: null);
            Reflector<Program>.Create("Car", new object[] { "some" });


        }
        public void TestMethod()
        {
            Console.WriteLine("some");
        }
        public void TestParamMethod(int i)
        {
            Console.WriteLine("some" + i);
        }
        public static void Some(string i)
        {
            Console.WriteLine("invoke" + i);
        }

    }
}