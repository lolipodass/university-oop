namespace RunProgram
{

    class Program
    {
        static void Main(string[] args)
        {

            List<Software> arr = new List<Software>();
            arr.Add(new Word());
            arr.Add(new Conficker());
            arr.Add(new Minesweeper());


            Printer print = new Printer();
            foreach (var item in arr)
            {
                print.IAmPrinting(item);
            }

        }
    }
}