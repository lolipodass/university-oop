namespace RunProgram
{

    public class Program12
    {

        static void Main(string[] args)
        {
            KALDirInfo.onUpdates += KALLog.WriteLog;
            KALFileInfo.onUpdates += KALLog.WriteLog;
            KALFileInfo.onUpdates += KALLog.WriteLog;
            KALFileManager.onUpdates += KALLog.WriteLog;


            KALDiskInfo.FreeSpaceShow(@"C:\");
            KALDiskInfo.AllDrivesInfoShow();
            KALDiskInfo.FileSystemInfoShow(@"C:\");


            KALFileInfo.FullPathShow(@"KALlogfile.txt");
            KALFileInfo.SizeExtensionShow(@"KALlogfile.txt");
            KALFileInfo.FileDatesShow(@"KALlogfile.txt");


            KALDirInfo.CreationTimeShow(@"C:\Users\joper\Desktop\-Flesha\software\C#");
            KALDirInfo.NumberOfFilesShow(@"C:\Users\joper\Desktop\-Flesha\software\C#");
            KALDirInfo.NumberOfSubdirectoriesShow(@"C:\Users\joper\Desktop\-Flesha\software\C#");
            KALDirInfo.ParentDirShow(@"KALlogfile.txt");


            KALFileManager.DiskInspect(@"C:\");
            KALFileManager.Copy(@"C:\Users\joper\Desktop\-Flesha\software\C#", ".txt");
            KALFileManager.WinRAR(@"C:\Users\joper\Desktop\-Flesha\software\C#\labs\1\ror",
             @"C:\Users\joper\Desktop\-Flesha\software\C#\labs\1\rar");

        }
    }
}