namespace RunProgram
{

    class Programe
    {
        static void Main(string[] args)
        {

            // Worm elem = new();
            // elem.DoIOperations();
            // ((IOperations)elem).DoIOperations();
            // try
            // {
            // List<Software> arr = new List<Software>();
            // arr.Add(new Word());
            // arr.Add(new Conficker());
            // arr.Add(new Minesweeper());

            // Printer print = new Printer();
            // foreach (var item in arr)
            // {
            //     print.IAmPrinting(item);
            // }


            // SoftwareContainer container = new SoftwareContainer(new Word());
            // container.Add(new Conficker());
            // container.Add(new Conficker("0.1.1"));
            // container.Add(new GameEngine("Unreal Engine"));
            // container.Add(new GameEngine("Unreal Engine", "0.1.1"));
            // container.Add(new Minesweeper("0.1.1"));
            // container.Add(new Game("Test Game", GameType.adventure, "0.2.1"));
            // container.Add(new Game("Test ne Game", GameType.shooter));
            // container.Add(new Game("Test ne Game3", GameType.adventure));
            // container.Add(new Game("Test ne Game4", GameType.shooter));
            // container.Delete(3);
            // // Console.WriteLine(((Game)container[7]).Type);
            // // Console.WriteLine(container);
            // Console.WriteLine("Games type");
            // Console.WriteLine(Controller.FindGames(container, GameType.shooter));
            // Console.WriteLine("Text editor");
            // Console.WriteLine(Controller.FindVersion(container, "0.0.1"));
            // Console.WriteLine("Sort");
            // Console.WriteLine(Controller.Sort(container));

            // int c = 0;
            // int i = 10 / c;

            // new Game("test", GameType.puzzle, "01.b.1");

            // container[10].ToString();
            // SoftwareContainer? elem = null;
            // Controller.FindGames(elem, GameType.shooter);}
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     Console.WriteLine();
            //     Console.WriteLine(e.StackTrace);
            //     Console.WriteLine();
            //     Console.WriteLine(e.Source);
            //     Console.WriteLine();
            //     Console.WriteLine(e.Message);

            // }
            // finally
            // {
            //     Console.WriteLine("block finally");
            // }
            Vector<Software> vector = new Vector<Software>();
            vector.Add(new Conficker());
            vector.Add(new Conficker("0.1.1"));
            vector.Add(new GameEngine("Unreal Engine"));
            vector.Add(new GameEngine("Unreal Engine", "0.1.1"));
            vector.Add(new Minesweeper("0.1.1"));
            vector.Add(new Game("Test Game", GameType.adventure, "0.2.1"));
            vector.Add(new Game("Test ne Game", GameType.shooter));
            vector.Add(new Game("Test ne Game3", GameType.adventure));
            vector.Add(new Game("Test ne Game4", GameType.shooter));
            // Console.WriteLine(vector);
            vector.Delete(1);
            vector.Delete(4);

            // vector.Delete(4);
            // vector.Delete(5);
            // vector.Delete(6);
            Vector<Software>.Serializable(vector);
            Vector<Software>.Deserialize();
            // Console.WriteLine(vector);

            // using (FileStream fl = new FileStream("test.ini", FileMode.OpenOrCreate))
            // {

            // }


        }

    }
}