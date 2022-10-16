
namespace RrProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(1, 2, 4);
            Vector vector2 = new Vector(7, 0, 42);
            Vector vector3 = new Vector(7, 0, 42);
            Vector vector4 = new Vector(7, 0, 42);
            Vector[] arrVector = { new Vector(1, 2), new Vector(32, 41, 0), new Vector(1, 2) };

            Console.WriteLine(Vector.AmountVectors);


            Console.WriteLine(arrVector[0].Equals(arrVector[2]));

            // foreach (var item in arrVector)
            // {
            //     for (int i = 0; i < item.length; i++)
            //     {
            //         if (item[i] == 0)
            //         {
            //             int? elem;
            //             item.Show(out elem);
            //             Console.WriteLine();
            //             break;
            //         }
            //     }
            // }
            var user = new { Name = "Tom", Age = 34 };
            Console.WriteLine(user);

        }
    }

    partial class Vector
    {
        private int[]? _array;
        public int length
        { get; private set; }
        public Exception? state;
        public readonly int ID;
        static int amountVectors;

        public static int AmountVectors => amountVectors;

        private Vector()
        {
            ID = AmountVectors;
            _array = null;
            amountVectors++;
        }
        static Vector()
        {
            amountVectors = 0;
        }

        public Vector(params int[] elements) : this()
        {
            _array = elements;
            length = _array.Length;
        }

        public int? this[int index]
        {
            get
            {
                if (_array == null)
                {
                    state = new NullReferenceException();
                    return null;
                }
                else
                    return index < length ? _array[index] : null;
            }
            set
            {
                if (_array != null)
                {
                    if (index > length)
                        _array[length] = value ?? 0;
                    else
                        _array[index] = value ?? 0;
                }
            }
        }

        public void AddNumber(ref int number)
        {
            for (int i = 0; i < length; i++)
            {
                if (_array != null)
                    _array[i] += i;
            }
        }
        public void MultipleNumber(in int number)
        {
            for (int i = 0; i < length; i++)
            {
                if (_array != null)
                    _array[i] *= i;
            }
        }

        public void Show(out int? first)
        {
            first = null;
            if (_array == null)
                return;
            for (int i = 0; i < length; i++)
            {
                Console.Write(_array[i] + " ");
            }
            first = _array[0];
        }
        public void Add(int num)
        {
            if (_array == null)
            {
                _array = new int[1] { num };
                return;
            }

            int[] temp = new int[length + 1];
            for (int i = 0; i < length; i++)
            {
                temp[i] = _array[i];
            }
            temp[length] = num;
            _array = temp;
            length = _array.Length;
        }




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
            return HashCode.Combine<int[]>(_array ?? new int[] { 0 });
        }

        public override string? ToString()
        {
            if (_array is null)
            { return null; }
            else
            { return string.Join(",", _array); }
        }
    }
}