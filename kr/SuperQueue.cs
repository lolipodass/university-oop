namespace Run
{
    public class SuperQueue<T>
    where T : struct
    {
        private Queue<T> _queue;
        public SuperQueue()
        { _queue = new(); }
        public void Add(T elem)
        {
            _queue.Enqueue(elem);
            if (_queue.Count >= 4)
                throw new Exception();
        }
    }
}