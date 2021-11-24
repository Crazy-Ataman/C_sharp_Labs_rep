using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Lab13_sharp
{
    static class DMLLog
    {
        public static void AddEntry(string option, string path, string message)
        {
            using (StreamWriter sw = new(@"..\..\..\DMLLogFile.txt", true))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine($"{option}: {path}");
                sw.WriteLine(message);
                sw.Close();
            }
        }

        public static void ClearFile()
        {
            // false - full file cleanup
            using (StreamWriter sw = new(@"..\..\..\DMLLogFile.txt", false))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Clear log file.");
                sw.Close();
            }
        }

        public static void GetLogEntries(string words)
        {
            Console.WriteLine("\nLog entries:");
            using var stream = new StreamReader(@"..\..\..\DMLLogFile.txt");
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                if (line.Contains(words))
                {
                    Console.WriteLine(line);
                }
            }
            stream.Close();
            AddEntry("DMLLog",
                "DMLLogFile.txt",
                "Retrieving entries by a given date/day/word.\n");
        }

        public static void CountAllEntries()
        {
            AddEntry("DMLLog",
                "DMLLogFile.txt",
                "Retrieving counts of lines in the file.");
            Console.WriteLine($"\nLog entries count: {File.ReadLines(@"..\..\..\DMLLogFile.txt").Count() + 1}\n");
        }

        public static void DeleteEntriesFromLog()
        {
            using var streamReader = new StreamReader(@"..\..\..\DMLLogFile.txt");
            var entries = new List<string>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains($"{DateTime.Now.Hour}"))
                {
                    entries.Add(line);
                }
            }
            streamReader.Close();
            using var streamWriter = new StreamWriter(@"..\..\..\DMLLogFile.txt", false);
            entries.ForEach(x => streamWriter.WriteLine(x));
            streamWriter.Close();
            AddEntry("DMLLog",
                "DMLLogFile.txt",
                "Leaving entries with current hour.\n");
        }
    }
}
