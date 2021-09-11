using System;
//using System.Globalization;
using System.Text;
using System.Linq;

namespace Lab2_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1a
            bool boolvar = true;    // true/false.
            byte bytevar = 255;     // [0, 255], 1 byte.
            sbyte sbytevar = -128;  // [-128, 127], 1 byte.
            short shvar = 32767;    // [-32768, 32767], 2 bytes.
            ushort ushvar = 65535;  // [0, 65535], 2 bytes.
            int intvar = 19;        // 19(10) = 0b10011(2) = 0x13(16) [-2147483648, 2147483647], 4 bytes.
            uint uintvar = 16;      // [0, 4294967295], 4 bytes.
            nint nintvar = 1;       // "Clever" integer. Adaptive size from the system: 4 bytes in the 32-bit and 8 bytes in the 64-bit version.
            nuint nuintvar = 2;     // Same as nint, but without the sign.
            long longvar = 25;      // [–9 223 372 036 854 775 808, 9 223 372 036 854 775 807], 8 bytes.
            ulong ulongvar = 23;    // [0, 18 446 744 073 709 551 615], 8 bytes.
            float flvar = 20.0289f; // Precision 6-7 digits in decimal part, 4 bytes.
            double douvar = 13.9097;// Precision 15 digits in decimal part, 8 bytes.
            decimal decvar = 34.99M;// Precision 28 digits in decimal part, 16 bytes.
            char chvar = 'D';       // 2 bytes.
            Console.WriteLine("Bool: {14}\nByte: {13}\nSbyte: {12}\nShort: {11}\nUshort: {10}\nInt: {9}\nUint: {8}\nNint: {7}\nNuint: {6}\nLong: {5}\n" +
                "Ulong: {4}\nFloat: {3}\nDouble: {2}\nDecimal: {1}\nChar: {0}", chvar, decvar, douvar, flvar, ulongvar, longvar, nuintvar, nintvar,
                uintvar, intvar, ushvar, shvar, sbytevar, bytevar, boolvar);

            // 1b
            // Явное преобразование.
            bytevar = (byte)uintvar;
            intvar = int.Parse("99");
            // Different cultures - different ways of notation for fractional numbers. RUS - ',', US - '.'.
            // Need a library System.Globalization;
            //IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            //decvar = decimal.Parse("2021.09", formatter);
            decvar = decimal.Parse("2021,09");
            douvar = Convert.ToDouble(flvar);
            // Convert.ToSingle - Converts the specified string representation of a number to an equivalent single-precision floating-point number,
            // using the specified culture-specific formatting information.
            flvar = Convert.ToSingle(decvar);
            // Неявное преборазование.
            nintvar = shvar; // Zero extension.
            longvar = sbytevar; // Copied together with sign bits. 
            ulongvar = uintvar; // long = int -> long
            douvar = flvar; // double = float -> double
            intvar = bytevar; // int = byte -> int

            // 1c
            Object boxing = intvar;
            int unboxing = (int)boxing;

            // 1d
            var ImplictVar = 14.56; // double
            Console.WriteLine($"\nImplictVar: {ImplictVar}");

            // 1e
            //int? NullVar = null;
            Nullable<int> NullVar = null;
            Console.WriteLine($"\nNullVar: {NullVar}");

            // 1f
            //ImplictVar = "Crazy";

            // 2a
            string nickname = "Crazy_Ataman";
            string realname = "Maksim";
            // String.Compare: will show how many characters are missing.
            if (String.Equals(nickname, realname) == true)
            {
                Console.WriteLine($"\n{nickname}\n{realname}\nEqual strings.");
            }
            else
            {
                Console.WriteLine($"\n{nickname}\n{realname}\nVarious strings.");
            }

            // 2b
            string str = "Stronger";
            string end = "together";
            string words = "rock, pop, jaz";
            string sentence = str + ' ' + end + '.';    // Concatenation 
            string copystr = sentence;                  // Copy
            string only_rock = words.Substring(0, 4);   // Substring highlighting 
            string[] Music = words.Split(", ");         // Splitting a string 
            Console.Write("\nMusic: ");
            foreach (string s in Music)                 
            {
                Console.Write(s + " ");
            }
            // Inserting a substring at a given position.
            Console.WriteLine("\n" + words.Trim(new char[] { 'r', 'o', 'c', 'k', ',', ' ', 'p', 'z', 'a' })
                + end.Trim(new char[] { 't', 'g', 'e', 'h', 'r' }) + 'k' + str.Substring(6));
            // Deleting a given substring. 
            Console.WriteLine("\n" + words.Substring(0, 4) + str.Remove(0, 6));

            // 2c
            string emptystr = "";
            string nullstr = null;
            // IsNullOrWhiteSpace ignore also whitespaces.
            if (String.IsNullOrEmpty(emptystr) && String.IsNullOrEmpty(nullstr))
            {
                Console.WriteLine("\nBoth strings is empty or null.");
            }
            else
            {
                Console.WriteLine("\nOne of the lines is not empty or null.");
            }

            // 2d
            StringBuilder strbuild = new StringBuilder("give your soul");
            strbuild.Remove(4, 10);
            strbuild.Insert(0, "\nNever ");
            strbuild.Append(" up!");
            Console.WriteLine(strbuild);

            // 3a
            int[,] twodimarray = new int[3, 3] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };
            Console.WriteLine("_________________|");
            for (int i = 0; i < twodimarray.GetLength(0); i++)      //GetLength(0) - row
            {
                for (int j = 0; j < twodimarray.GetLength(1); j++)  //GetLength(0) - column
                {
                    Console.Write(twodimarray[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------|");

            // 3b
            Console.WriteLine("\nArray of music:");
            foreach (string s in Music)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine($"Length of this array: {Music.Length} elements");
            try
            {
                Console.Write("Enter a position: ");
                // Console.ReadLine() string -> int
                int pos = Convert.ToInt32(Console.ReadLine());
                if (pos > Music.Length || pos <= 0)
                {
                    throw new Exception("Wrong position!");
                }
                Console.Write("Enter a value: ");
                string new_value = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(new_value))
                {
                    throw new Exception("Wrong value!");
                }

                Music[pos - 1] = new_value;
                Console.Write("New array of music: ");
                foreach (string s in Music)
                {
                    Console.Write(s + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! " + ex.Message);
            }

            // 3c
            float[][] flarry = new float[3][];
            flarry[0] = new float[2];
            flarry[1] = new float[3];
            flarry[2] = new float[4];

            //Console.WriteLine("\nEnter the array elements: ");
            //for (int i = 0; i < flarry.Length; i++)
            //{
            //    for (int j = 0; j < flarry[i].Length; j++)
            //    {
            //        Console.Write($"Array[{i}][{j}]: ");
            //        flarry[i][j] = Single.Parse(Console.ReadLine());
            //    }
            //}
            //Console.WriteLine("\nStepped array: ");
            //for (int i = 0; i < flarry.Length; i++)
            //{
            //    for (int j = 0; j < flarry[i].Length; j++)
            //    {
            //        Console.Write(flarry[i][j] + "\t");
            //    }
            //    Console.WriteLine();
            //}

            // 3d
            var somevar = new short[] { 99, 33, 13, 69, 29 };
            var strvar = "Trollface";

            // 4a
            (int, string, char, string, ulong) tuple = (19, "Maksim", 'M', "Dashchynski", 3627868);

            // 4b
            Console.WriteLine("\n\tInformation about me");
            Console.WriteLine("Age: " + tuple.Item1);
            Console.WriteLine("Name: " + tuple.Item2);
            Console.WriteLine("Gender: " + tuple.Item3);
            Console.WriteLine("Full name: " + tuple.Item4);
            Console.WriteLine("Telephone number: " + tuple.Item5);

            // Partial output from tuple.
            Console.WriteLine("\n" + tuple.Item2 + ' ' + tuple.Item4);

            // 4c
            (var x, var y) = (666, "77");
            Console.WriteLine("\n" + x + ' ' + y);
            // Owner Ivan will not be available. 
            var (model, year, _) = ("Z4", 2002, "Ivan");

            // 4d
           var tuple_for_compare_1 = ( 10, "good work");
           var tuple_for_compare_2 = ( 11, "good job");
            if (tuple_for_compare_1 == tuple_for_compare_2)
            {
                Console.WriteLine("\nTuples are equal.");
            }
            else
            {
                Console.WriteLine("\nTuples are NOT equal.");
            }

            // 5
            Tuple<int, int, int, char> Local_Func(int[] num, string str)
            {
                return Tuple.Create(num.Max(), num.Min(), num.Sum(), str[0]);
            }
            int[] arr_numbers = { 13, 9, 99 };
            string str_for_func = "Mad";
            Tuple<int, int, int, char> tuple_local_func = Local_Func(arr_numbers, str_for_func);
            Console.WriteLine("\nTuple: " + tuple_local_func);

            // 6
            void Func_1()
            {
                try
                {
                    checked
                    {
                        int overflow = int.MaxValue;
                        overflow++;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("An overflow has occurred. (Func_1)");
                }
            }
            void Func_2()
            {
                try
                {
                    unchecked // Never shows an overflow message.
                    {
                        int overflow = int.MaxValue;
                        overflow++;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("An overflow has occurred. (Func_2)");
                }
            }
           
            Func_2();
            Func_1();
        }
    }
}
