namespace Name
{
    public class Program
    {

        static void Main(string[] args)
        {




            Shop shop1 = new Shop(new[] { "elem1", "elem2", "elem3", "elem4" },
                            new[] { 1, 2, 3, 4 }, 4);

            Shop shop2 = new Shop(new[] { "elem1", "elem2", "elem3", "elem4", "elem5" },
                            new[] { 1, 2, 3, 4, 5 }, 5);

            Console.WriteLine(shop1.Compare(shop2));
            Console.WriteLine(shop2.Compare(shop1));



            int[,] arr = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i % 2 == 0 && j % 2 == 1) || (i % 2 == 1 && j % 2 == 0))
                        arr[i, j] = 1;
                }
            }


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(arr[i, j] + ", ");
                }
                Console.Write('\n');
            }

            // string str;

            // str = Console.ReadLine();
            // Console.WriteLine(str);
        }
    }
}
