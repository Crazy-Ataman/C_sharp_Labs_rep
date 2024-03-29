﻿using System;

namespace Lab4_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize class Owner.
            // 1 way
            //Set<string>.Owner[] owners = new Set<string>.Owner[3];
            //owners[0] = new Set<string>.Owner("Max", "BSTU");
            //owners[1] = new Set<string>.Owner("Alexander", "BSTU");
            //owners[2] = new Set<string>.Owner("Artem", "BSTU");
            // 2 way 
            Set<string>.Owner[] owners = new Set<string>.Owner[3]
            {
                new Set<string>.Owner("Max", "BSTU"),
                new Set<string>.Owner("Alexander", "BSTU"),
                new Set<string>.Owner("Artem", "BSTU")
            };
            Console.WriteLine("List of owners: ");
            foreach (Set<string>.Owner owner in owners)
                owner.ShowOwners();
            Console.Write("\n");

            // Initialize class Date.
            var current_date = new Set<string>.Date();
            Console.WriteLine("Current date: ");
            current_date.ShowDate();
            Console.Write("\n");

            // Changing color of text in console.
            Console.ForegroundColor = ConsoleColor.Green;
            var set1 = new Set<string>() { };
            set1.Add("Hell world");
            set1.Add("1");
            set1.Add("Good morning");
            set1.Add("Rock");
            Console.WriteLine("Items from set1: ");
            set1.ShowSet();

            var set2 = new Set<string>() { };
            set2.Add("Hell world");
            set2.Add("9");
            set2.Add("Good morning");
            set2.Add("Rock and pop");
            set2.Add("Everlasting evening");
            string dash_50 = new('-', 50);
            Console.WriteLine(dash_50);
            Console.WriteLine("Items from set2: ");
            set2.ShowSet();

            var set3 = new Set<int>() { };
            set3.Add(99);
            set3.Add(13);
            set3.Add(67);
            set3.Add(707);
            set3.Add(15);
            Console.WriteLine(dash_50);
            Console.WriteLine("Items from set3: ");
            set3.ShowSet();

            var set4 = new Set<int>() { };
            set4.Add(99);
            set4.Add(13);
            set4.Add(67);
            set4.Add(707);
            set4.Add(15);
            Console.WriteLine(dash_50);
            Console.WriteLine("Items from set4: ");
            set4.ShowSet();

            // Remove => -(type of the item must be explicitly declared)
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(dash_50);
            Console.WriteLine("Remove item \"1\" from set1...");
            set1 -= "1";
            Console.WriteLine("Items from set1: ");
            set1.ShowSet();

            // Intersection => *
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(dash_50);
            Console.WriteLine("Intersection set1 with set2...");
            Console.WriteLine("set1 * set2:");
            (set1 * set2).ShowSet();

            // Subset => >
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(dash_50);
            Console.WriteLine($"Subset: set1 > set2 => {set1 > set2}");
            Console.WriteLine($"Subset: set3 < set4 => {set3 > set4}");
            // Subset (inverse) => <
            Console.WriteLine($"Subset (inverse): set1 < set2 => {set1 < set2}");
            Console.WriteLine($"Subset (inverse): set3 > set4 => {set3 < set4}");

            // Difference => &
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(dash_50);
            Console.WriteLine("Difference: set1 & set2:");
            (set2 & set1).ShowSet();

            // Number of items in set.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(dash_50+"\nNumber of items in set1: ");
            Console.WriteLine(StatisticOperation.Count_items_of_set(set1));
            Console.WriteLine("Items from set1: ");
            set1.ShowSet();

            // Difference between maximum and minimum string.
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(dash_50 + "\nDifference between maximum and minimum string in set2: ");
            Console.WriteLine(set2.Difference_max_and_min());
            Console.WriteLine("Items from set2: ");
            set2.ShowSet();

            // Concat all strings.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(dash_50 + "\nConcat all strings in set1: ");
            Console.WriteLine(set1.Concat_all_strings());
            Console.WriteLine("Items from set1: ");
            set1.ShowSet();

            // Adding dot at the end of string.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(dash_50 + "\nOrigin set1: ");
            set1.ShowSet();
            Console.WriteLine("Adding dot at the end...");
            set1.DotAtTheEnd(set1);
            Console.WriteLine("Current set1:");
            set1.ShowSet();

            // Deleting items with 0 value (string).
            Console.ForegroundColor = ConsoleColor.Yellow;
            set1.Add(null);
            Console.WriteLine(dash_50 + "\nOrigin set1: ");
            set1.ShowSet();
            Console.WriteLine("Deleting items with 0 values...");
            set1.DeletingNull(set1);
            Console.WriteLine("Current set1:");
            set1.ShowSet();

            // Deleting items with 0 value (int).
            Console.ForegroundColor = ConsoleColor.White;
            set3.Add(0);
            Console.WriteLine(dash_50 + "\nOrigin set3: ");
            set3.ShowSet();
            Console.WriteLine("Deleting items with 0 values...");
            set3.DeletingNull(set3);
            Console.WriteLine("Current set3:");
            set3.ShowSet();
        }
    }
}