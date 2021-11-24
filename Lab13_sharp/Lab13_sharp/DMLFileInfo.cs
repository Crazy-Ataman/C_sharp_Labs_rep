using System;
using System.IO;

namespace Lab13_sharp
{
    static class DMLFileInfo
    {
        public static void FullPath(string path)
        {
            FileInfo file = new(path);

            Console.WriteLine($"Full path to the file {file.Name}: {file.FullName}\n");

            DMLLog.AddEntry("DMLFileInfo", file.Name, "Retrieving full path to the file.\n");
        }

        public static void FileInfo(string path)
        {
            FileInfo file = new(path);

            Console.WriteLine($"File name: {file.Name}");
            Console.WriteLine($"File size: {Math.Round((float)file.Length / 1000, 2)} KB");
            Console.WriteLine($"File extension: {file.Extension}\n");

            DMLLog.AddEntry("DMLFileInfo", file.Name, "Retrieving basic information about file.\n");
        }

        public static void FileCreationChanges(string path)
        {
            FileInfo file = new(path);

            Console.WriteLine($"File creation time {file.Name}: {file.CreationTime}");
            Console.WriteLine($"File edit time {file.Name}: {file.LastWriteTime}\n");

            DMLLog.AddEntry("DMLFileInfo", file.Name, "Retrieving file creation and changes.\n");
        }
    }
}
