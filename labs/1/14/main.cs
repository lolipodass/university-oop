using System.Diagnostics;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;

namespace RunProgram
{
    public class Program14
    {
        private static object locker = new object();
        public static void Main()
        {













            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("\n\n2");
            Console.WriteLine("Name " + domain.FriendlyName);
            Console.WriteLine("ID " + domain.Id);
            Console.WriteLine("Configuration " + domain.SetupInformation);
            Console.WriteLine("Catalog " + domain.BaseDirectory);


            Console.WriteLine("all process: ");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(
                    $"-> Name: \t{asm.GetName().Name}\n" +
                    $"-> Version: \t{asm.GetName().Version}\n"
                    );
            }

            AppDomain newD = AppDomain.CreateDomain("MyNewAppDomain");
            InfoDomainApp(newD);
            AppDomain.Unload(newD);




            Console.WriteLine("Введите число:");
            int number1 = int.Parse(Console.ReadLine() ?? "0");

            Thread myThread = new Thread(SimpleNumbers);
            myThread.Name = "SimpleNumbersThread";
            myThread.Start(number1);



            int number2 = int.Parse(Console.ReadLine() ?? "0");

            Thread myThread1 = new Thread(new ParameterizedThreadStart(EvenAndOdd));
            myThread1.Name = "EvenNumbersThread";
            myThread1.Priority = ThreadPriority.Normal;
            Console.WriteLine($"Поток: {myThread1.Name}   Приоритет: {myThread1.Priority}");
            myThread1.Start(number2);

            Thread myThread2 = new Thread(new ParameterizedThreadStart(EvenAndOdd));
            myThread2.Name = "OddNumbersThread";
            myThread2.Priority = ThreadPriority.BelowNormal;
            Console.WriteLine($"Поток: {myThread2.Name}   Приоритет: {myThread2.Priority}");
            myThread2.Start(number2);

            Console.ReadLine();



            TimerCallback tm = new TimerCallback(MethodForTimer);
            Timer timer = new Timer(tm, null, 0, 5000);

        }

        static void InfoDomainApp(AppDomain defaultD)
        {
            Console.WriteLine("<--- Информация о новом домене приложения --->\n");
            Console.WriteLine(
                $"Имя: {defaultD.FriendlyName}\n" +
                $"ID: {defaultD.Id}\n" +
                $"По умолчанию? {defaultD.IsDefaultAppDomain()}\n" +
                $"Путь: {defaultD.BaseDirectory}\n"
                );

            Console.WriteLine("Загружаемые сборки: \n");
            var infAsm = from asm in defaultD.GetAssemblies()
                         orderby asm.GetName().Name
                         select asm;
            foreach (var a in infAsm)
                Console.WriteLine(
                    $"-> Имя: \t{a.GetName().Name}\n" +
                    $"-> Версия: \t{a.GetName().Version}"
                    );
        }
        public static void SimpleNumbers(object num)
        {
            string Path = "SimpleNumbers.txt";
            Thread t = Thread.CurrentThread;
            for (int i = 2; i <= (int)num; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0 & i % 1 == 0)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    Console.WriteLine(i);
                    using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(i);
                    }
                    Thread.Sleep(400);
                }
                if (i == (int)num)
                {
                    Console.WriteLine($"Имя потока: {t.Name}");
                    Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
                    Console.WriteLine($"Приоритет потока: {t.Priority}");
                    Console.WriteLine($"Статус потока: {t.ThreadState}");
                }
            }
        }
        public static void EvenAndOdd(object num)
        {
            string Path = "EvenAndOddNumbers.txt";
            Thread t = Thread.CurrentThread;
            lock (locker)
            {
                for (int i = 0; i < (int)num; i++)
                {
                    if (t.Name == "EvenNumbersThread")
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i);
                            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(i);
                            }
                        }
                        Thread.Sleep(300);
                    }

                    if (t.Name == "OddNumbersThread")
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i);
                            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(i);
                            }
                        }
                        Thread.Sleep(300);
                    }
                }
            }
        }
        public static void MethodForTimer(object param)
        {
            Console.WriteLine("SOME TEXT SOME TEXT SOME TEXT SOME TEXT SOME TEXT SOME TEXT SOME TEXT SOME TEXT SOME TEXT SOME TEXT ");
        }
    }
}
