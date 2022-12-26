namespace RunProgram
{
    public class KALLog23 : IDisposable
    {
        private FileStream fs;
        private StreamReader read;
        private StreamWriter write;

        public KALLog23()
        {
            fs = new("KALlogfile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            read = new(fs);
            write = new(fs);
        }

        public void Write(string message, string FileName)
        {
            // write.Write(message);
            DateTime time = DateTime.Now;
            using (StreamWriter sr = new(fs))
                sr.WriteLine(message + "\t\t\t" + FileName + "\t\t\t" + time);
        }


        public string? Read(int index)
        {
            using (var sr = new StreamReader(fs))
            {
                Console.WriteLine("some");
                for (int i = 1; i < index; i++)
                    sr.ReadLine();
                string? str = sr.ReadLine();
                Console.WriteLine(str);
                return str;
            }
        }
        public void Dispose()
        {
            fs.Dispose();
            // read.Dispose();
            // write.Dispose();
        }
    }
}