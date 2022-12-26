namespace Run
{
    public class Window
    {
        private string _name;
        public Window(string name)
        {
            _name = name;
        }

        public int Resize(int size)
        {
            Console.WriteLine($"window {_name} resized to {size}");
            return size;
        }
        public void Resome(int size)
        {
            Console.WriteLine($"window {_name} Resome to {size}");
        }
    }
}