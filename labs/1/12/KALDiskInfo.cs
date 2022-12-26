namespace RunProgram
{
    public static class KALDiskInfo
    {
        /*2. Создать класс XXXDiskInfo c методами для вывода информации о
a.свободном месте на диске
b. Файловой системе
c.Для каждого существующего диска - имя, объем, доступный
объем, метка тома.
d.Продемонстрируйте работу класса*/
        public static event Action<string>? onUpdates;
        public static void FreeSpaceShow(string disk)
        {
            var currentDisk = DriveInfo.GetDrives().Single(x => x.Name == disk);
            Console.WriteLine($"Свободное место на диске {currentDisk.Name}: {currentDisk.AvailableFreeSpace} байт...");
            onUpdates?.Invoke($"[LOG] Свободное место на диске {currentDisk.Name}: {currentDisk.AvailableFreeSpace} байт...");
        }

        public static void FileSystemInfoShow(string disk)
        {
            var currentDisk = DriveInfo.GetDrives().Single(x => x.Name == disk);
            Console.WriteLine($"Информация о файловой системе диска {disk} : {currentDisk.DriveType}\t-\t{currentDisk.DriveFormat}");
            onUpdates?.Invoke($"[LOG] Информация о файловой системе диска {disk} : {currentDisk.DriveType}\t-\t{currentDisk.DriveFormat}");
        }

        public static void AllDrivesInfoShow()
        {
            Console.WriteLine("All drives info:\n");

            foreach (var currentDisk in DriveInfo.GetDrives())
            {
                if (currentDisk.IsReady == false)
                {
                    continue;
                }
                Console.WriteLine($"Имя диска:\t{currentDisk.Name.ToString()}\nРазмер:\t{currentDisk.TotalSize}\nСвободное место:\t{currentDisk.AvailableFreeSpace}\nМетка тома:\t{currentDisk.VolumeLabel}");
                onUpdates?.Invoke($"[LOG] Имя диска:\t{currentDisk.Name.ToString()}\nРазмер:\t{currentDisk.TotalSize}\nСвободное место:\t{currentDisk.AvailableFreeSpace}\nМетка тома:\t{currentDisk.VolumeLabel}");
            }
        }
    }
}
