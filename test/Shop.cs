


namespace Name
{

    interface ICompare
    {
        public bool Compare(Shop elem);
    }

    public class Shop : ICompare
    {
        private string[] _names;
        private int[] _prices;


        public Shop(string[] names, int[] prices, int length)
        {
            _names = names;
            _prices = prices;
            this.length = length;
        }
        public int length
        { get; private set; }

        public bool Compare(Shop elem)
        {
            if (length > elem.length)
                return true;
            return false;
        }
        public string this[int index]
        {
            get
            {
                return index < length ? $"{_names[index]}:{_prices[index]}" :
                $"{_names[length]}:{_prices[length]}";
            }
            set
            {
                if (index > length)
                    _names[length] = value;
                else
                    _names[index] = value;
            }
        }
    }
}