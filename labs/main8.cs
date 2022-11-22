namespace RunProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            User main = new();
            main.EventMove += (i) => { Console.WriteLine("Move"); };
            main.EventMove += (i) => { Console.WriteLine($"Move {i}"); };
            main.EventMove += (i) => { Console.WriteLine($"Move to {i}"); };
            main.EventMove += (new Subscriber()).Showing;

            main.Moving(10);
            Subscriber subscriber = new();

            main.EventShrink += (i) => { Console.WriteLine("Shrink"); };
            main.EventShrink += subscriber.Save;

            main.Shrinking(10);
            main.Shrinking(10);
            main.Shrinking(10);
            Console.WriteLine(subscriber.Sum);


            string word = "test String. jooj";
            word = StringModifier.DelegateFunc(word, StringModifier.Lower);
            Console.WriteLine(word);
            word = StringModifier.DelegateFunc(word, StringModifier.Upper);
            Console.WriteLine(word);
            word = StringModifier.DelegateFunc(word, StringModifier.InsertDots);
            Console.WriteLine(word);
            word = StringModifier.DelegateFunc(word, StringModifier.DeleteDots);
            Console.WriteLine(word);
            word = StringModifier.DelegateFunc(word, StringModifier.Reverse);
            Console.WriteLine(word);
        }
    }

}