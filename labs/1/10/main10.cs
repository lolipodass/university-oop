namespace RunProgram
{
    class Program10
    {
        public static void Main()
        {
            // !1
            string[] months =
            { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            var allWithLenN = from n in months
                              where n.Length == 5
                              select n;
            var SortByName = from n in months
                             orderby n ascending
                             select n;
            var withUAndLength = from n in months
                                 where n.Length > 4 && n.Contains('u')
                                 select n;


            Console.WriteLine("1");
            Console.WriteLine("All with length 5");
            foreach (var item in allWithLenN)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("sorted by Name");
            foreach (var item in SortByName)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("with letter 'u' and length>4");
            foreach (var item in withUAndLength)
            {
                Console.WriteLine(item);
            }

            // !2

            List<Vector> cars = new();
            cars.Add(new(0, 1, 2));
            cars.Add(new(13, 84, 57));
            cars.Add(new(16, 28, -4));
            cars.Add(new(2, 15, 44));
            cars.Add(new(1, 32, 26));
            cars.Add(new(20, -12, 49));
            cars.Add(new(35, 6, 15));
            cars.Add(new(25, 18, 17));
            cars.Add(new(28, 23, -8));
            cars.Add(new(9, 49, 17));
            cars.Add(new(47, -3, 31));
            cars.Add(new(28, 7, 20));
            cars.Add(new(45, 49, 20));
            cars.Add(new(9, 40, 30));
            cars.Add(new(26, 23, 16));
            cars.Add(new(20, 47, 49));
            cars.Add(new(20, 47, 49));
            cars.Add(new(20, 47, 49));
            cars.Add(new(49, 17, 32));
            cars.Add(new(44, 17, 22));
            cars.Add(new(36, 22, 34));
            cars.Add(new(15, 32, 17));
            cars.Add(new(20, 4, 10));
            cars.Add(new(6, 24, 24));
            cars.Add(new(41, 47, 11));
            cars.Add(new(49, 21, 30));

            // !3
            Console.WriteLine("3");
            var with0 = from n in cars
                        where n.x == 0 || n.y == 0 || n.z == 0
                        select n;


            Console.WriteLine("with 0");
            foreach (var item in with0)
            {
                Console.WriteLine(item);
            }


            int lowest = cars.Min(entry => entry.x + entry.y + entry.z);
            var lowestABS = from n in cars
                            where n.x + n.y + n.z == lowest
                            select n;

            Console.WriteLine("lowestABS");
            foreach (var item in lowestABS)
            {
                Console.WriteLine(item);
            }
            int highest = cars.Max(entry => entry.x + entry.y + entry.z);

            var Length1 = from n in cars
                          where n.x + n.y + n.z < highest || n.x > 10
                          select n;
            var Length2 = from n in cars
                          where n.x + n.y + n.z < highest || n.y > 20
                          select n;
            var Length3 = from n in cars
                          where n.x + n.y + n.z < highest || n.z > 30
                          select n;
            Console.WriteLine("length1");
            foreach (var item in Length1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("length2");
            foreach (var item in Length2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("length3");
            foreach (var item in Length3)
            {
                Console.WriteLine(item);
            }
            var FirstNegative = (from n in cars
                                 where n.x < 0 || n.y < 0 || n.z < 0
                                 select n).FirstOrDefault();
            var FirstNegative1 = cars.Where(n => n.x < 0 || n.y < 0 || n.z < 0).FirstOrDefault();


            Console.WriteLine(FirstNegative);
            Console.WriteLine(FirstNegative1);

            var Sorted = from n in cars
                         orderby n.x + n.y + n.z
                         select n;
            Console.WriteLine("sorted");
            foreach (var item in Sorted)
            {
                Console.WriteLine(item);
            }

            // !4
            Console.WriteLine("4");
            var complex = (from n in cars.Distinct()
                           where n.x > 5
                           orderby n.z descending
                           select n.y).Skip(2);

            // !5
            Console.WriteLine("5");
            var joins = from n in cars
                        where n.y < 20
                        join mon in months on n.x equals months.Length
                        select n;



        }

    }
}