namespace RunProgram
{

    public class CarList<T> : IList<T>
    where T : notnull
    {
        private T[] _contents = new T[16];
        private int _count;

        public CarList()
        {
            _count = 0;
        }

        // IList Members
        public void Add(T value)
        {
            if (_count < _contents.Length)
            {
                _contents[_count] = value;
                _count++;
            }
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _contents.CopyTo(array, arrayIndex);
        }


        public int IndexOf(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T value)
        {
            if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _contents[i] = _contents[i - 1];
                }
                _contents[index] = value;
            }
        }

        public bool IsFixedSize
        { get { return true; } }

        public bool IsReadOnly
        { get { return false; } }

        public bool Remove(T value)
        {
            RemoveAt(IndexOf(value));
            return true;
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _contents[i] = _contents[i + 1];
                }
                _count--;
            }
        }

        public T this[int index]
        {
            get
            { return _contents[index]; }
            set
            { _contents[index] = value; }
        }

        // ICollection members.

        public int Count
        { get { return _count; } }

        public bool IsSynchronized
        { get { return false; } }

        // IEnumerable Members


        public Enumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(_contents, _count);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator<T>(_contents, _count);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(_contents, _count);
        }

        public void PrintContents()
        {
            Console.WriteLine($"List has a capacity of {_contents.Length} and currently has {_count} elements.");
            Console.Write("List contents:");
            for (int i = 0; i < Count; i++)
            {
                Console.Write($" {_contents[i]}");
            }
            Console.WriteLine();
        }
    }

    public struct Enumerator<T> : IEnumerator<T>
    {
        private T[] _content;
        private int _count = 0;
        private int index = -1;
        public Enumerator(T[] array, int Count)
        {
            _content = array;
            _count = Count;
        }

        public void Dispose()
        { }

        public T current
        { get { return _content[index]; } }

        public bool MoveNext()
        {
            index++;
            return (index < _count);
        }
        public void Reset() => index = -1;

        public T Current
        { get { return _content[index]; } }
        Object System.Collections.IEnumerator.Current
        {
            get
            {
                try
                {
                    return _content[index] ?? throw new NullReferenceException();
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
