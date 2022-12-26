using System.Security.Cryptography;
using System.Text;

namespace Runtime
{

    class ProgrameS
    {
        public static void Maine()
        {
            int FuncEiler(int p, int q)
            {
                return (p - 1) * (q - 1);
            }

            int PowMod(int bas, int exp, int modulus)
            {
                bas %= modulus;
                int result = 1;
                while (exp > 0)
                {
                    if (exp % 2 == 1) result = (result * bas) % modulus;
                    bas = (bas * bas) % modulus;
                    exp >>= 1;
                }
                return result;
            }


            int p = 47, q = 59;
            int e = 257;
            int d = 1;

            Console.WriteLine("type text for encrypt");
            string word = Console.ReadLine() ?? "";
            Encrypted element = new Encrypted(word);
            string h = element.MD();
            Console.WriteLine($"hash for message: {h}");

            while ((d * e - 1) % FuncEiler(p, q) != 0) d++;


            Console.WriteLine($"d= {d}");
            List<int> a = new List<int>();
            for (int i = 0; i < h.Length; i++)
            {
                a.Add(PowMod((int)(h[i]), e, p * q));
            }

            Console.WriteLine($"digital key: ");
            foreach (int b in a) Console.Write(b);
            Console.WriteLine(" ");
            char c = ' ';
            string H = "";
            for (int i = 0; i < h.Length; i++)
            {
                c = (char)(PowMod(a[i], d, p * q));
                H += c;
            }

            Console.WriteLine($"compute hash from digital signature: {H}");
            if (H == h && element.MD() == H) Console.WriteLine($"digital signature correct");
        }
    }

    public class Encrypted
    {
        public string message;

        public Encrypted(string x)
        {
            message = x;
        }
        public string MD()
        {
            using var provider = MD5.Create();
            StringBuilder builder = new StringBuilder();
            foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(message)))
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }
    }
}

