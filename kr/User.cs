namespace Run
{
    public delegate void Move(int distance);
    public class User
    {
        public event Func<int, int>? moved;
        public Move? almostMoved;
        public void Move(int position)
        {
            Console.WriteLine("moved");
            moved?.Invoke(position);
            almostMoved?.Invoke(position);
        }
    }
}