using System;
using System.IO;
using System.IO.Compression;

namespace Lab13_sharp
{
    static class DMLFileManager
    {
        public static void InspectDirectoty(string path)
        {
            DirectoryInfo directory = new(path);

            Directory.CreateDirectory(@"..\..\..\DMLInspect");
            File.Create(@"..\..\..\DMLInspect\DMLDirInfo.txt").Close();

            using (StreamWriter sw = new(@"..\..\..\DMLInspect\DMLDirInfo.txt"))
            {
                sw.WriteLine("|Directories|");
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    sw.WriteLine(dir.Name);
                }

                sw.Write("\n");

                sw.WriteLine("|Files|");
                foreach (FileInfo file in directory.GetFiles())
                {
                    sw.WriteLine(file.Name);
                }

                sw.Close();
            }

            File.Copy(@"..\..\..\DMLInspect\DMLDirInfo.txt", @"..\..\..\DMLInspect\DMLDirInfoCopiedAndRenamed.txt", true);
            File.Delete(@"..\..\..\DMLInspect\DMLDirInfo.txt");
        }

        public static void CopyFiles(string path, string extension)
        {
            DirectoryInfo directory = new(path);
            Directory.CreateDirectory(@"..\..\..\DMLFiles");

            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension == extension)
                {
                    file.CopyTo($@"..\..\..\DMLFiles\{file.Name}", true);
                }
            }

            DirectoryInfo directoryExist = new(@"..\..\..\DMLInspect\DMLFiles\");
            // Need to delete directory, if we have it, otherwise get exception.
            if (directoryExist.Exists)
            {   
                Directory.Delete(@"..\..\..\DMLInspect\DMLFiles", true);
            }
            Directory.Move(@"..\..\..\DMLFiles\", @"..\..\..\DMLInspect\DMLFiles\");
        }

        public static void Archive(string pathFrom, string pathTo)
        {


            if (!File.Exists($@"{pathFrom}.zip"))
            {
                ZipFile.CreateFromDirectory(pathFrom, $@"{pathFrom}.zip");
            }

            ZipFile.ExtractToDirectory($@"{pathFrom}.zip", pathTo, true);
        }
    }
}
