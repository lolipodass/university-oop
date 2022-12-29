using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace RunProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raz();
            Dva();
            Tri();
            Chetire();
            Pyat();
            Shest();
            //Sem();
            Vosem();

        }

        #region Задание 1
        //Используя TPL создайте длительную по времени задачу(на основе Task) на выбор:
        //Поиск простых чисел решетом Эратосфена
        /*Выведите идентификатор текущей задачи, проверьте во время 
        выполнения – завершена ли задача и выведите ее статус.
        2) Оцените производительность выполнения используя объект 
        Stopwatch на нескольких прогонах.*/
        static void Raz()
        {
            Stopwatch stopwatch = new Stopwatch();


            Task<uint> task = new Task<uint>(() => CountColvoOfSimpleNumbers(10));

            Console.WriteLine($"Task ID: {task.Id}\n Task status: {task.Status}\n---");
            stopwatch.Start();
            task.Start();


            Console.WriteLine($"Task ID: {task.Id}\n Task status: {task.Status}\n---");
            task.Wait();
            stopwatch.Stop();
            Console.WriteLine($"Task ID: {task.Id}\n Task status: {task.Status}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Метод отработал {stopwatch.ElapsedMilliseconds} мс...");
            Console.WriteLine($"{task.Result}\n\n\n"); // -- Не работает св-во Result
        }

        private static uint CountColvoOfSimpleNumbers(uint enumerationStop)
        {
            List<uint> numbers = new List<uint>();
            for (uint i = 2u; i < enumerationStop; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (uint j = 0; j < enumerationStop; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }
            return (uint)numbers.Count;
        }
        #endregion

        #region Задание 2
        /*Реализуйте второй вариант этой же задачи с токеном отмены
        CancellationToken и отмените задачу*/
        static void Dva()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Task secondTask = Task.Factory.StartNew(CountColvoOfSimpleNumbersWithCancelation, cancellationToken);

            try
            {
                cancellationTokenSource.Cancel();
                secondTask.Wait();
            }
            catch (AggregateException e)
            {

                if (secondTask.IsCanceled)
                {
                    Console.WriteLine($"Задача {secondTask.Id} отменена..");
                }
            }
        }
        private static uint CountColvoOfSimpleNumbersWithCancelation(object obj)
        {
            List<uint> numbers = new List<uint>();
            var token = (CancellationToken)obj;
            for (uint i = 2u; i < 50; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Canceled request");
                    //token.ThrowIfCancellationRequested();
                    return 0;
                }
                for (var j = 2u; j < 1000; j++) numbers.Remove(numbers[i] * j);
            }
            return (uint)numbers.Count;
        }
        #endregion

        #region Задание 3
        /*Создайте три задачи с возвратом результата и используйте их для
        выполнения четвертой задачи.Например, расчет по формуле*/
        static void Tri()
        {
            Task<int> sum = new Task<int>(() => new Random().Next() + new Random().Next());
            Task<int> mul = new Task<int>(() => new Random().Next() * new Random().Next());
            Task<int> slash = new Task<int>(() => new Random().Next() / new Random().Next());
            sum.Start();
            mul.Start();
            slash.Start();

            sum.Wait();
            mul.Wait();
            slash.Wait();

            Task<int> vichisleniya = new Task<int>(() => sum.Result + mul.Result + slash.Result);
        }
        #endregion

        #region Задание 4
        /*Создайте задачу продолжения(continuation task) в двух вариантах:
        1) C ContinueWith -планировка на основе завершения множества
        предшествующих задач
        2) На основе объекта ожидания и методов GetAwaiter(),GetResult();*/
        static void Chetire()
        {
            //1
            Task<int> sum = new Task<int>(() => new Random().Next() + new Random().Next());
            Task showSum = sum.ContinueWith(t => Console.WriteLine(sum.Result));
            sum.Start();

            //2
            Task<int> getAwaiterAndResult = Task.Run(() => sum.Result + new Random().Next());

            TaskAwaiter<int> awaiter = getAwaiterAndResult.GetAwaiter();

            awaiter.OnCompleted(async () => { int res = awaiter.GetResult(); Console.WriteLine("Результат sum: " + res); });
            Console.WriteLine(awaiter.GetResult());
        }
        #endregion

        #region Задание 5
        /*Используя Класс Parallel распараллельте вычисления циклов For(),
        ForEach().Например, на выбор: обработку(преобразования)
        последовательности, генерация нескольких массивов по 1000000
        элементов, быстрая сортировка последовательности, обработка текстов
        (удаление, замена). Оцените производительность по сравнению с
        обычными циклами*/
        static void Pyat()
        {
            int[] array1 = new int[1000000];
            int[] array2 = new int[1000000];
            int[] array3 = new int[1000000];

            Stopwatch st = new Stopwatch();

            st.Start();

            void CreateElems(int i)
            {
                array1[i] = 1;
                array2[i] = 2;
                array3[i] = 3;
            }
            Parallel.For(0, 1000000, CreateElems);
            st.Stop();
            Console.WriteLine($"Parallel справился за: {st.ElapsedMilliseconds} ms");

            st.Restart();

            for (int i = 0; i < 1000000; i++)
            {
                array1[i] = 1;
                array2[i] = 2;
                array3[i] = 3;
            }
            st.Stop();
            Console.WriteLine($"For справился за: {st.ElapsedMilliseconds} ms");
        }
        #endregion

        #region Задание 6
        /*Используя Parallel.Invoke() распараллельте выполнение блока
        операторов.*/
        static void Shest()
        {
            int[] array1 = new int[1000000];
            int[] array2 = new int[1000000];
            int[] array3 = new int[1000000];

            Stopwatch st = new Stopwatch();
            st.Start();
            Parallel.Invoke(
                () =>
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        array1[i] = 1;
                    }
                },
                () =>
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        array2[i] = 2;
                    }
                },
                () =>
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        array3[i] = 3;
                    }
                });
            st.Stop();
            Console.WriteLine($"Parallel.Invoke справился за {st.ElapsedMilliseconds} ms");
        }
        #endregion

        #region Задание 7
        /*Используя Класс BlockingCollection реализуйте следующую задачу:
        Есть 5 поставщиков бытовой техники, они завозят уникальные товары
        на склад(каждый по одному) и 10 покупателей – покупают все подряд, 
        если товара нет - уходят.В вашей задаче: cпрос превышает
        предложение.Изначально склад пустой.У каждого поставщика своя
        скорость завоза товара.Каждый раз при изменении состоянии склада
        выводите наименования товаров на складе.*/
        static void Sem()
        {
            BlockingCollection<string> bc = new BlockingCollection<string>(5);

            Task[] consumers = new Task[10]
            {
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(200);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(300);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(250);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(150);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(400);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(350);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(300);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(250);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(700);
                        bc.Take();
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }
                ),
            };

            Task[] sellers = new Task[5]
            {
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(350);
                        bc.Add("Кофемолка");
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Чайник");
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(750);
                        bc.Add("Сковорода");
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(900);
                        bc.Add("Холодильник");
                    }
                }
                ),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(200);
                        bc.Add("Кофеварка");
                    }
                }
                ),
            };


            foreach (var i in sellers)
            {
                if (i.Status != TaskStatus.Running)
                {
                    i.Start();
                }
            }
            foreach (var i in consumers)
            {
                if (i.Status != TaskStatus.Running)
                {
                    i.Start();
                }
            }

            void Stopper()
            {
                foreach (var i in sellers)
                {
                    if (i.Status != TaskStatus.Running)
                    {
                        i.Wait();
                    }
                }
                foreach (var i in consumers)
                {
                    if (i.Status != TaskStatus.Running)
                    {
                        i.Wait();
                    }
                }
            }

            int count = 1;
            bool flag = true;
            while (flag)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(500);
                    Console.WriteLine("Склад:");
                    foreach (var item in bc)
                    {
                        Console.WriteLine(item);
                    }
                }

            }
        }
        #endregion

        #region Задание 8
        /*Используя async и await организуйте асинхронное выполнение любого
        метода.*/
        static void Vosem()
        {
            void Count1000minus7()
            {
                int tis = 1000;
                int result = tis;
                while (result > 3)
                {
                    result -= 7;
                    Console.WriteLine($"{tis} - 7 = {result}");
                }

            }

            async void Count1000minus7async()
            {
                await Task.Run(() => Count1000minus7());
            }
            Count1000minus7();
            Console.WriteLine("-");
            Count1000minus7async();
        }
        #endregion
    }
}