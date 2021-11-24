using System;

namespace Lab13_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //DMLLog.ClearFile();

            DMLDiskInfo.FreeSpace("C:\\");
            DMLDiskInfo.FileSystemInfo("C:\\");
            DMLDiskInfo.DriveFullInfo();

            DMLFileInfo.FullPath(@"..\..\..\DMLLogFile.txt");
            DMLFileInfo.FileInfo(@"..\..\..\DMLLogFile.txt");
            DMLFileInfo.FileCreationChanges(@"..\..\..\DMLLogFile.txt");

            DMLDirInfo.CountFile(@"..\..\..\..\Lab13_sharp");
            DMLDirInfo.CreationTime(@"..\..\..\..\Lab13_sharp");
            DMLDirInfo.SubDirectoryCount(@"..\..\..\..\Lab13_sharp");
            DMLDirInfo.ParentDirectory(@"..\..\..\..\Lab13_sharp");

            DMLFileManager.InspectDirectoty(@"..\..\..\..\Lab13_sharp");
            DMLFileManager.CopyFiles(@"..\..\..\..\Lab13_sharp", ".txt");
            DMLFileManager.Archive(@"..\..\..\DMLInspect\DMLFiles",
                @"..\..\..\My_unzip_file");

            DMLLog.GetLogEntries("24.11.2021");
            DMLLog.CountAllEntries();
            //DMLLog.DeleteEntriesFromLog();
        }
    }
}
