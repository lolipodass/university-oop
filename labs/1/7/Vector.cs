using System.Runtime.Serialization.Formatters.Binary;

namespace RunProgram
{
    [Serializable]
    public class Vector<T> : ICollection<T>
    where T : notnull
    {
        private T[] _array;
        public int length
        { get; private set; }

        public Vector() => _array = new T[0];
        public Vector(params T[] elements)
        {
            _array = elements;
            length = _array.Length;
        }

        public bool Add(T element)
        {
            try
            {
                T[] buff = new T[length + 1];
                Array.Copy(_array, buff, length);
                buff[length] = element;
                _array = buff;
                length++;
                return true;
            }
            catch
            { return false; }
        }

        public T Delete(int index)
        {
            length--;
            T[] buff = new T[length];
            Array.Copy(_array, buff, index);
            Array.Copy(_array, index + 1, buff, index, length - index);
            T buff2 = _array[index];
            _array = buff;
            return buff2;
        }


        public T GetValue(int index) => _array[index];
        public T[] Show() => _array;


        public T this[int index]
        {
            get
            {
                if (index > length)
                    throw new IndexOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index > length)
                    throw new IndexOutOfRangeException();

                _array[index] = value;
            }
        }

        public bool IsEmpty() => _array == null ? true : false;

#pragma warning disable SYSLIB0011
        public static void Serializable(Vector<T> elem)
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("test.ini", FileMode.OpenOrCreate))
            {
                Formatter.Serialize(fs, elem);
            }
        }
        public static void Deserialize()
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("test.ini", FileMode.Open))
            {
                Console.WriteLine(Formatter.Deserialize(fs));
            }
        }
#pragma warning restore SYSLIB0011

        public override bool Equals(object? obj)
        {

            if (obj == null || GetType() != obj.GetType())
            { return false; }

            if (obj.ToString() == this.ToString())
            { return true; }
            else
            { return false; }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine<T[]>(_array ?? new T[0]);
        }

        public override string ToString()
        {
            return String.Join(",", _array);
        }
    }
}