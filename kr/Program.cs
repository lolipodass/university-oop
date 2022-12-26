namespace Run
{
    public class Program
    {

        static void Main()
        {
            Console.WriteLine("first");
            SuperQueue<DateTime> queue = new();
            queue.Add(new DateTime());
            queue.Add(new DateTime());
            queue.Add(new DateTime());
            // queue.Add(new DateTime());


            Console.WriteLine("second");
            string[] arr = { "start", "second", "first", "another", "some", "a", "someLongWord" };

            var result = (from elem in arr
                          orderby elem.Length, elem
                          select elem).Take(3);


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("third");

            User some = new();
            Window first = new("first");
            Window second = new("second");
            some.almostMoved += first.Resome;
            some.moved += second.Resize;
            some.Move(10);
        }


    }

}