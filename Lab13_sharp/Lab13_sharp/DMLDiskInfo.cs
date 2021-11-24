using System;
using System.IO;

namespace Lab13_sharp
{
    static class DMLDiskInfo
    {
        public static void FreeSpace(string driveName)
        {
            foreach(DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == driveName && drive.IsReady)
                {
                    // Default output: C:\
                    // With Substring: C 
                    Console.WriteLine($"Free space on the {drive.Name.Substring(0, 1)} drive: {Math.Round((float)drive.TotalFreeSpace / 1_073_741_824, 2)} GB\n");

                    DMLLog.AddEntry("DMLDiskInfo", driveName, "Retrieving free disk space information.\n");
                }
            }
        }

        public static void FileSystemInfo(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == driveName && drive.IsReady)
                {
                    Console.WriteLine($"File system type of {drive.Name.Substring(0, 1)} drive: {drive.DriveFormat}\n");

                    DMLLog.AddEntry("DMLDiskInfo", drive.Name, "Retrieving disk format.\n");
                }
            }
        }

        public static void DriveFullInfo()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Name: {drive.Name}");
                    Console.WriteLine($"Volume: {Math.Round((float)drive.TotalSize / 1_073_741_824, 2)} GB");
                    Console.WriteLine($"Available free space: {Math.Round((float)drive.AvailableFreeSpace / 1_073_741_824, 2)} GB");
                    Console.WriteLine($"Volume label: {drive.VolumeLabel}\n");

                    DMLLog.AddEntry("DMLDiskInfo", drive.Name, "Retrieving disk information.\n");
                }
            }
        }
    }
}
