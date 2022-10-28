using System.Diagnostics;
namespace RunProgram
{
    public class SoftwareContainer
    {
        private Software[] _array;
        public int length
        { get; private set; }


        public SoftwareContainer(SoftwareContainer cont) => _array = cont._array;

        public SoftwareContainer(Software element)
        {
            _array = new[] { element };
            length = 1;
        }


        public override string ToString()
        {
            Debug.Assert(length > 0);
            System.Text.StringBuilder str = new();
            for (int i = 0; i < length; i++)
            {
                str.Append(
                    $"{_array[i].ToString()},Name:{_array[i].ShowName()}, Version:{_array[i].Version}  \n");
            };
            return str.ToString();
        }



        public Software this[int index]
        {
            get
            {
                if (index < 0 || index > length)
                    throw new ContainerException("out of range");
                return _array[index];
            }
            set
            {
                if (_array is null)
                    throw new ContainerException("is empty");
                if (index > length)
                    throw new ContainerException("out of range");

                _array[index] = value;
            }
        }

        public void Sort()
        {
            Array.Sort(_array);
        }

        public void Add(Software value)
        {
            Software[] temp = new Software[length + 1];
            for (int i = 0; i < length; i++)
            {
                temp[i] = _array[i];
            }
            temp[length] = value;
            _array = temp;
            length++;
        }
        public void Delete(int position)
        {
            if (position < 0)
                throw new ContainerException("out of range");

            _array = (_array[0..position]).Concat(_array[(position + 1)..length]).ToArray();
            length--;
        }
    }
}
