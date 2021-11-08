using System;
using System.Collections.Generic;

namespace Lab9_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Students>
            {
                new("FIT"), // Faculty of Information Technology 
                new("FCTE"),// Faculty of Chemical Technology and Engineering 
                new("FTOS") // Faculty of Technology of Organic Substances
            };

            var directors = new List<Director>
            {
                new("Mark, FIT", 5000),
                new("Vanya, FCTE", 1000),
                new("Anya, FTOS", 2100)
            };

            Console.WriteLine("List of directors:");
            directors.ForEach(x => Console.WriteLine($"Name: {x.Name}\nMoney: {x.Money}$\nFines: {x.FineCounter}"));

            directors[0].Fine += students[0].GossipAboutFine;
            directors[1].Raise += students[1].GossipAboutRaise;
            directors[2].Raise += students[2].GossipAboutRaise;
            directors[2].Fine += students[2].GossipAboutFine;

            Console.ForegroundColor = ConsoleColor.Red;
            directors[0].GetFine();
            Console.ForegroundColor = ConsoleColor.Green;
            directors[1].RaiseDirector();
            directors[2].RaiseDirector();
            Console.ForegroundColor = ConsoleColor.Red;
            directors[2].GetFine();

            Console.ForegroundColor = ConsoleColor.White;
            directors[0].ShowInfo();
            directors[1].ShowInfo();
            directors[2].ShowInfo();

            const string str = "Three HUNDRED BUCKS in my pocket,,,,,,, YeA??! ::;;";
            Console.WriteLine($"\n{"Original string".PadRight(32)}: {str}");
            Func<string, string> strfunc = StringEditor.ToLower;
            Console.WriteLine($"{"StringEditor.ToLower()".PadRight(32)}: {strfunc(str)}");
            strfunc = StringEditor.ToUpper;
            Console.WriteLine($"{"StringEditor.ToUpper()".PadRight(32)}: {strfunc(str)}");
            strfunc = StringEditor.RemoveSpaces;
            Console.WriteLine($"{"StringEditor.RemoveSpaces()".PadRight(32)}: {strfunc(str)}");
            strfunc = StringEditor.RemovePunctuation;
            Console.WriteLine($"{"StringEditor.RemovePunctuation()".PadRight(32)}: {strfunc(str)}");
            strfunc = StringEditor.AddSymbol;
            Console.WriteLine($"{"StringEditor.AddSymbol()".PadRight(32)}: {strfunc(str)}");

        }
    }
}
