using System.IO.Compression;

namespace RunProgram
{
    public static class KALFileManager
    {
        /* Создать класс XXXFileManager.Набор методов определите
 самостоятельно.С его помощью выполнить следующие действия:
 a.Прочитать список файлов и папок заданного диска.Создать
 директорий XXXInspect, создать текстовый файл
 xxxdirinfo.txt и сохранить туда информацию.Создать
 копию файла и переименовать его. Удалить
 первоначальный файл.
 b.Создать еще один директорий XXXFiles.Скопировать в
 него все файлы с заданным расширением из заданного
 пользователем директория. Переместить XXXFiles в
 XXXInspect.
 c.Сделайте архив из файлов директория XXXFiles. 
 Разархивируйте его в другой директорий*/
        public static event Action<string>? onUpdates;

        public static void DiskInspect(string diskName)
        {
            Directory.CreateDirectory("KALInspect");

            var currentDisk = DriveInfo.GetDrives().Single(x => x.Name == diskName);
            onUpdates?.Invoke($"[LOG] Файловый менеджер создал директорию {currentDisk.Name}");
            File.Create(@"KALInspect\KALdirinfo.txt").Close();

            using (var stream = new StreamWriter(@"KALInspect\KALdirinfo.txt"))
            {

                stream.WriteLine("Dirs: ");
                foreach (var item in currentDisk.RootDirectory.GetDirectories())
                {
                    stream.WriteLine($"{item.Name}");
                }

                stream.WriteLine("Files: ");

                foreach (var item in currentDisk.RootDirectory.GetFiles())
                {
                    stream.WriteLine($"{item.Name}");
                }

            }
            File.Copy(@"KALInspect\KALdirinfo.txt", @"KALInspect\KALdirinfocopy.txt");

            File.Delete(@"KALInspect\KALdirinfox.txt");

        }
        public static void Copy(string path, string ext)
        {
            var dir = new DirectoryInfo(path);
            Directory.CreateDirectory("KALFiles");

            foreach (var file in dir.GetFiles())
            {
                if (file.Extension == ext)
                {
                    file.CopyTo(@$"KALFiles\{file.Name}");
                    Directory.Delete(@"KALInspect\KALFiles\");
                    Directory.Move(@"KALFiles\", @"KALInspect\KALFiles\");
                }
            }
            onUpdates?.Invoke($"[LOG] Файловый менеджер скопировал {ext} файлы из {path}");
        }

        public static void WinRAR(string pathFrom, string pathTo)
        {
            // Directory.Delete(@"Unarchivive\");
            if (!File.Exists($@"{pathFrom}.zip"))
            {
                ZipFile.CreateFromDirectory(pathFrom, $@"{pathFrom}.zip");

            }
            ZipFile.ExtractToDirectory($@"{pathFrom}.zip", pathTo);
            onUpdates?.Invoke($"[LOG] Файловый менеджер заархивировал файлы из {pathFrom} и разархивировал в {pathTo}");
        }
    }
}