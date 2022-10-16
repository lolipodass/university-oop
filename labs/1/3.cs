
namespace RuProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector = new Vector(7, 0, 42, 12, 10, -1, 29);
            Vector[] arrVector = { new Vector(1, 2), new Vector(32, 41, 0), new Vector(1, 2) };
            vector.Delete(0);
            Console.WriteLine(vector);
            Vector.Developer test = new Vector.Developer();

        }
    }



    public class Production
    {
        public int ID
        { get; private set; }
        public string Name
        { get; private set; }

        public Production() => Name = "";
        public Production(int ID) { this.ID = ID; Name = ""; }
        public Production(int ID, string Name) { this.ID = ID; this.Name = Name; }
        public Production(string Name) { this.Name = Name; }
    }



    public class Vector
    {
        private int[]? _array;
        public int length
        { get; private set; }

        public Production production = new();

        public Vector() => _array = null;
        public Vector(params int[] elements)
        {
            _array = elements;
            length = _array.Length;
        }
        public int this[int index]
        {
            get
            {
                if (_array == null)
                {
                    throw new NullReferenceException();
                }
                else
                    return index < length ? _array[index] : _array[length];
            }
            set
            {
                if (_array != null)
                {
                    if (index > length)
                        _array[length] = value;
                    else
                        _array[index] = value;
                }
            }
        }
        public static Vector operator *(Vector elem1, Vector elem2)
        {

            int[] arr = new int[elem1.length];
            for (int i = 0; i < elem1.length; i++)
            {
                int buffSum = 0;
                for (int j = 0; j < elem2.length; j++)
                {
                    buffSum += elem1[i] * elem2[j];
                }
                arr[i] = buffSum;
            }
            return new Vector();
        }
        public static bool operator true(Vector elem1)
        {
            for (int i = 0; i < elem1.length; i++)
            {
                if (elem1[i] < 0)
                    return false;
            }
            return true;
        }
        public static bool operator false(Vector elem1)
        {
            for (int i = 0; i < elem1.length; i++)
            {
                if (elem1[i] < 0)
                    return true;
            }
            return false;
        }

        public static explicit operator int(Vector elem) => elem.length;
        public static bool operator ==(Vector elem1, Vector elem2) => elem1.Equals(elem2);
        public static bool operator !=(Vector elem1, Vector elem2) => !elem1.Equals(elem2);
        public static bool operator <(Vector elem1, Vector elem2) => elem1.length < elem2.length;
        public static bool operator >(Vector elem1, Vector elem2) => elem1.length > elem2.length;
        public void AddNumber(ref int number)
        {
            for (int i = 0; i < length; i++)
            {
                if (_array != null)
                    _array[i] += i;
            }
        }

        public bool IsEmpty() => _array == null ? true : false;
        public void MultipleNumber(in int number)
        {
            for (int i = 0; i < length; i++)
            {
                if (_array != null)
                    _array[i] *= i;
            }
        }

        public void ShowInConsole()
        {
            if (_array == null)
                return;
            for (int i = 0; i < length; i++)
            {
                Console.Write(_array[i] + " ");
            }
        }

        public int[]? Show() => _array;

        public void Add(int value)
        {
            if (_array == null)
            {
                _array = new int[1] { value };
                return;
            }

            int[] temp = new int[length + 1];
            for (int i = 0; i < length; i++)
            {
                temp[i] = _array[i];
            }
            temp[length] = value;
            _array = temp;
            length = _array.Length;
        }

        public void Delete(int position)
        {
            if (_array == null || position < 0)
                return;

            _array = (_array[0..position]).Concat(_array[(position + 1)..length]).ToArray();
            length--;
        }


        public class Developer
        {
            public int ID
            { get; private set; }

            public string division
            { get; private set; } = "";

            public string FullName
            { get; private set; } = "";

            public Developer() { }
            public Developer(int ID) => this.ID = ID;
            public Developer(int ID, string FullName) { this.ID = ID; this.FullName = FullName; }
            public Developer(int ID, string FullName, string division)
            { this.ID = ID; this.FullName = FullName; this.division = division; }
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


    public static class StatisticOperation
    {
        public static bool Contains(this string str, char elem)
        {
            foreach (var item in str)
            {
                if (item == elem)
                    return true;
            }
            return false;
        }
    }



    public static class VectorExtension
    {
        public static bool Contains(this Vector elem, int value)
        {
            for (int i = 0; i < elem.length; i++)
            {
                if (elem[i] == value)
                { return true; }
            }
            return false;
        }

        public static void DeleteNegative(this Vector elem)
        {
            for (int i = 0; i < elem.length; i++)
            {
                if (elem[i] < 0)
                    elem.Delete(i);
            }
        }

        public static int CalculateSum(this Vector elem)
        {
            int sum = 0;
            for (int i = 0; i < elem.length; i++)
            {
                sum += elem[i];
            }
            return sum;
        }

        public static int Difference(this Vector elem)
        {
            int min = elem[0], max = elem[0];
            for (int i = 0; i < elem.length; i++)
            {
                if (elem[i] < min)
                    min = elem[i];
                if (elem[i] > max)
                    max = elem[i];
            }
            return max - min;
        }

        public static int CalcLength(this Vector elem)
        {
            return elem.length;
        }
    }
}