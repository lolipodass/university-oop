using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RunProgram
{
    class Program9
    {
        static void Main(string[] args)
        {
            CarList<Car> list = new();
            list.Add(new("some"));
            list.Add(new("second"));
            list.Add(new("third"));
            list.Add(new("another"));
            list.PrintContents();
            list.RemoveAt(2);
            list.PrintContents();

            foreach (var c in list)
            {
                Console.WriteLine(c);
            }

            Dictionary<int, string> dict = new();
            SortedList<int, string> sorted = new();
            dict.Add(1, "list");
            dict.Add(2, "new()");
            for (int i = 0; i < 5; i++)
            {
                dict.Add(i + 3, i.ToString());
                sorted.Add(i + 3, i.ToString());
            }

            foreach (var c in dict)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("");
            foreach (var c in sorted)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine(sorted.IndexOfKey(1));
            Console.WriteLine(sorted.IndexOfKey(4));
            // dict.Remove(3);

            Console.WriteLine("3");
            ObservableCollection<string> observer = new();
            observer.CollectionChanged += some;
            observer.Add("some");

            void some(object? obj, NotifyCollectionChangedEventArgs e)
            {
                Console.WriteLine(obj);
            }

        }
    }
}
