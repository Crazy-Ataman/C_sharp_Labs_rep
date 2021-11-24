using System;
using System.IO;

namespace Lab13_sharp
{
    static class DMLDirInfo
    {
        public static void CountFile(string path)
        {
            Console.WriteLine($"Counts of files in the {path}: {Directory.GetFiles(path).Length}\n");

            DMLLog.AddEntry("DMLDirInfo", path, "Retrieving counts of files in the directory.\n");
        }

        public static void CreationTime(string path)
        {
            Console.WriteLine($"Times creation of files in the {path}: {Directory.GetCreationTime(path)}\n");

            DMLLog.AddEntry("DMLDirInfo", path, "Retrieving times creation of files in the directory.\n");
        }

        public static void SubDirectoryCount(string path)
        {
            Console.WriteLine($"Counts of subdirectories in the {path}: {Directory.GetDirectories(path).Length}\n");

            DMLLog.AddEntry("DMLDirInfo", path, "Retrieving counts of subdirectories in the directory.\n");
        }

        public static void ParentDirectory(string path)
        {
            Console.WriteLine($"Parent directory in the {path}: {Directory.GetParent(path)}\n");

            DMLLog.AddEntry("DMLDirInfo", path, "Retrieving parent directory in the directory.\n");
        }
    }
}
