namespace RunProgram
{
    public static class KALFileInfo
    {
        /*3. Создать класс XXXFileInfo c методами для вывода информации о
конкретном файле
a.Полный путь
b. Размер, расширение, имя
c. Дата создания, изменения
d. Продемонстрируйте работу класса*/
        public static event Action<string>? onUpdates;

        public static void FullPathShow(string path)
        {
            var currentFile = new FileInfo(path);

            Console.WriteLine($"Полный путь до файла {currentFile.Name}: \" {currentFile.FullName} \"");
            onUpdates?.Invoke($"[LOG] Полный путь до файла {currentFile.Name}: \" {currentFile.FullName} \"");

        }

        public static void SizeExtensionShow(string path)
        {
            var currentFile = new FileInfo(path);
            Console.WriteLine($"Имя файла:\t{currentFile.Name}\nРазмер:\t{currentFile.Length} байт.\nРасширение файла:\t{currentFile.Extension}\n");
            onUpdates?.Invoke($"[LOG] Имя файла:\t{currentFile.Name}\nРазмер:\t{currentFile.Length} байт.\nРасширение файла:\t{currentFile.Extension}\n");
        }

        public static void FileDatesShow(string path)
        {
            var currentFile = new FileInfo(path);
            Console.WriteLine($"Имя файла:\t{currentFile.Name}\nДата создания:\t{currentFile.CreationTime}\nДата последнего изменения:\t{currentFile.LastWriteTime}");
            onUpdates?.Invoke($"[LOG] Имя файла:\t{currentFile.Name}\nДата создания:\t{currentFile.CreationTime}\nДата последнего изменения:\t{currentFile.LastWriteTime}");
        }
    }
}