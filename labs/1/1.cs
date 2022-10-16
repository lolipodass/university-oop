
namespace project
{

    class Program
    {

        static void Main()
        {

            String();
        }
        static void Types()
        {
            bool Boolean = false;
            byte Byte = 255;
            sbyte Sbyte = 127;
            char Char = 'a';
            decimal Decimal = 1.2m;
            double Double = 2.7011;
            float Float = 2.80001f;
            int Int = 2_147_483_647;
            uint Uint = 4_294_967_295;
            nint Nint = 2_147_483_647;
            nuint Nuint = 2_147_483_648;
            long Long = 9_223_372_036_854_775_807;
            ulong Ulong = 18_446_744_073_709_551_615;
            short Short = -32768;
            ushort Ushort = 65535;


            Console.Write($"bool {Boolean}\n");
            Console.Write($"byte {Byte}\n");
            Console.Write($"sbyte {Sbyte}\n");
            Console.Write($"char {Char}\n");
            Console.Write($"decimal {Decimal}\n");
            Console.Write($"double {Double}\n");
            Console.Write($"float {Float}\n");
            Console.Write($"int {Int}\n");
            Console.Write($"uint {Uint}\n");
            Console.Write($"nint {Nint}\n");
            Console.Write($"nuint {Nuint}\n");
            Console.Write($"long {Long}\n");
            Console.Write($"ulong {Ulong}\n");
            Console.Write($"short {Short}\n");
            Console.Write($"ushort {Ushort}\n");


            Console.Write(Boolean + "Boolean \n");
            char? test = Convert.ToChar(Console.Read());
            Boolean = Convert.ToBoolean(test);
            Console.Write(Boolean + "Boolean \n");

            Byte = (byte)Console.Read();
            Sbyte = (sbyte)Console.Read();
            Decimal = (decimal)Console.Read();
            Double = (double)Console.Read();
            Float = (float)Console.Read();

            byte cast = 11;
            Short = cast;
            Int = cast;
            Long = cast;
            Long = Int;
            Int = cast;


            object box = cast;
            Long = (long)box;

            var implicitly = "10";


            dynamic dim = implicitly;
            dim = 10;
        }

        static void String()
        {
            string str1 = "10rgfgjlksf df fsdafsf s";
            string str2 = "121gfsgd";
            Console.Write(str1 == str2 ? "true" : "false" + "\n");




            string str3 = "sjndf fkmdjf dkfjd";
            Console.WriteLine(string.Concat(str1, str2, str3));
            Console.WriteLine();
            Console.WriteLine(string.Equals("str2", "str1"));
            str3 = str1;
            Console.WriteLine(str1.Substring(6));
            for (int i = 0; i < 3; i++)
                Console.WriteLine(str1.Split(' ')[i]);
            Console.WriteLine(str1.Insert(10, str1.Substring(12)));
            Console.WriteLine(str1.Replace(str1.Substring(12), ""));
            Console.WriteLine($"Строка str1: {str1}");


            string str4 = "";
            string? str5 = null;
            Console.WriteLine(string.IsNullOrEmpty(str4));
            Console.WriteLine(string.IsNullOrEmpty(str5));
            Console.WriteLine(str4 == str5);


            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("string 1");
            sb1.Insert(sb1.Length, "+1");
            sb1.Remove(3, 4);
            Console.WriteLine(sb1);
        }

        static void Array()
        {

            int[,] arr1 = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    arr1[i, j] = i + j;
                    Console.Write("{0} ", arr1[i, j]);
                    if (j == 2)
                        Console.WriteLine();
                }




            string[] arrStr = new string[3] { "s1", "s2", "s3" };
            Console.WriteLine(arrStr.Length);
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{0} ", arrStr[i]);
            }
            Console.WriteLine();
            string? strbsd = Console.ReadLine();
            int strPosit = Convert.ToInt32(strbsd);
            string? strP = Console.ReadLine();
            arrStr[strPosit] = strP ?? "da";
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{0} ", arrStr[i]);
            }



            double[][] jaggedFloatArr = new double[3][];
            jaggedFloatArr[0] = new double[2];
            jaggedFloatArr[1] = new double[3];
            jaggedFloatArr[2] = new double[4];

            for (int j = 0; j < 2; j++)
                jaggedFloatArr[0][j] = Convert.ToDouble(Console.ReadLine());
            for (int j = 0; j < 3; j++)
                jaggedFloatArr[1][j] = Convert.ToDouble(Console.ReadLine());
            for (int j = 0; j < 4; j++)
                jaggedFloatArr[2][j] = Convert.ToDouble(Console.ReadLine());



            var que3d = new int[2];
            var que3d2 = new System.Text.StringBuilder();
        }

        static void Tuple()
        {

            (int, string, char, string, ulong) c1 = (12, "sd", '2', "dsjdf", 923284938482938428L);



            Console.WriteLine($"Элем1 - {c1.Item1}, элем3 - {c1.Item3}, элем5 - {c1.Item5}");



            int intC3 = c1.Item1;
            string strC31 = c1.Item2;
            char charC3 = c1.Item3;
            string strC32 = c1.Item4;
            ulong longC3 = c1.Item5;


            var c2 = c1;
            Console.WriteLine($"c2 == c1 {c2 == c1}, c2 != c1 {c2 != c1}");




            (int, int, int, char) func1(int[] intArr, string strF)
            {
                int sum = 0, min = int.MaxValue, max = int.MinValue;
                for (int i = 0; i < intArr.Length; i++)
                    sum += intArr[i];
                for (int i = 0; i < intArr.Length; i++)
                {
                    if (min > intArr[i])
                        min = intArr[i];

                    if (max < intArr[i])
                        max = intArr[i];
                }
                return (max, min, sum, strF[0]);
            }
            int[] sdsa = { 2, 4, 5, 7, 232, -322, 34 };
            func1(sdsa, "skdkjs");


        }

        static void Ets()
        {
            void func2()
            {
                try
                {
                    int int123 = checked(int.MaxValue);
                    Console.WriteLine(int123);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            func2();

            void func3()
            {
                try
                {
                    int int123 = unchecked(int.MaxValue);
                    Console.WriteLine(int123);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            func3();

        }

    }

}