namespace RunProgram
{
    public static class KALLog
    {
        public static void WriteLog(string message)
        {
            using (var stream = new StreamWriter("KALlogfile.txt", true))
            {
                stream.WriteLine($"{DateTime.Now.ToString()}\t-\t{message}");
            }
        }
        /*Создать класс XXXLog.Он должен отвечать за работу с текстовым файлом
xxxlogfile.txt.в который записываются все действия пользователя и
соответственно методами записи в текстовый файл, чтения, поиска нужной
информации*/
    }
}