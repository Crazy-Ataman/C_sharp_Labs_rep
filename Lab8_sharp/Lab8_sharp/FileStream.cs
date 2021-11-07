using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab8_sharp
{
    class FileStream
    {
        public static void ReadFile(Set<string> set)
        {
            using StreamReader sr = new(@"..\..\..\file_in.txt");
            string[] str = sr.ReadToEnd().Split("-->");
            foreach (var el in str)
            {
                set.Add(el);
            }
        }

        public static void WriteToFile(Set<string> set) 
        {
            using StreamWriter sw = new(@"..\..\..\file_out.txt");
            foreach (var el in set)
            {
                sw.Write(el);
                if (el != set.items[set.Count - 1])
                {
                    sw.Write("-->");
                }
            }


        }
    }
}
