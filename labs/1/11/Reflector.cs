
namespace RunProgram11
{
    [Serializable]
    public static class Reflector<T>
    where T : class
    {
        public static void Name()
        {
            Console.WriteLine(typeof(T).Assembly.FullName);
        }

        public static void HaveConstructor()
        {
            var elem = typeof(T).GetConstructors();
            foreach (var item in elem)
            {
                Console.WriteLine(item);
            }
        }
        public static void PublicMethods()
        {
            var methods = typeof(T).GetMembers();
            foreach (var elem in methods)
            {
                Console.WriteLine(elem);
            }
        }
        public static void Fields()
        {
            Console.WriteLine("properties");
            var props = typeof(T).GetProperties();
            foreach (var elem in props)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("fields");
            var field = typeof(T).GetFields();
            foreach (var elem in field)
            {
                Console.WriteLine(elem);
            }
        }

        public static void Interfaces()
        {
            var interfaces = typeof(T).GetInterfaces();
            foreach (var elem in interfaces)
            {
                Console.WriteLine(elem);
            }
        }

        public static void MethodsWithParam(Type Name)
        {
            var methods = typeof(T).GetMethods();
            foreach (var i in methods)
            {
                var elem = i.GetParameters();
                foreach (var ele in elem)
                {
                    if (ele.ParameterType == Name)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
        }

        static public void MyInvoke(string name, string method)
        {
            using (StreamReader file = new StreamReader("test.txt"))
            {
                string param = file.ReadLine() ?? "";
                var mthod = typeof(T).GetMethod(name);
                mthod?.Invoke(null, new object[] { param });
            }
        }
        public static object Create(string name, object[]? param)
        {
            var type = Type.GetType("RunProgram." + name);
            if (type == null)
            {
                Console.WriteLine("type not found");
                return new object();
            }
            object? obj = Activator.CreateInstance(type, param);
            if (obj == null)
            {
                Console.WriteLine("cant create instance with this params");
                return new object();

            }
            Console.WriteLine(obj.ToString());
            return obj;

        }

    }
}