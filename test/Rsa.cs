using System.Security.Cryptography;
using System.Text;
namespace Name
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\joper\Desktop\-Flesha\software\C#\test\";
            var message = Encoding.UTF8.GetBytes("Hello  ");
            using (FileStream fs = File.Create(path + "hash.txt"))
            {

                using (var alg = SHA512.Create())
                {
                    var hashValue = alg.ComputeHash(message);
                    fs.Write(hashValue);
                    fs.Flush();
                }
            }

            using (var alg = new RSACryptoServiceProvider(2048))
            {
                var crypt = alg.Encrypt(message, true);
                using (FileStream fs = File.Create(path + "crypted.txt"))
                {
                    fs.Write(crypt);
                    fs.Flush();
                }
                var decrypt = alg.Decrypt(crypt, true);
                using (FileStream fs = File.Create(path + "decrypted.txt"))
                {
                    fs.Write(decrypt);
                    fs.Flush();
                }
                using (FileStream fs = File.Create(path + "keys.txt"))
                {
                    fs.Write(Encoding.UTF8.GetBytes(alg.ToXmlString(true)));
                    fs.Flush();
                }
            }
        }
    }
}
