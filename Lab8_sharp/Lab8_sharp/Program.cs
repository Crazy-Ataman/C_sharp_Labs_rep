using System;

namespace Lab8_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Limitation: no more than 4 elements in a set.
            try
            {
                // Changing color of text in console.
                Console.ForegroundColor = ConsoleColor.White;

                var set1 = new Set<string>() { };
                set1.Add("Hell world");
                set1.Add("1");
                set1.Add("Good morning");
                set1.Add("Rock");
                Console.WriteLine("Items from set1: ");
                set1.Show();

                string dash_50 = new('-', 50);
                Console.WriteLine(dash_50);
                Console.WriteLine("Deleting element \"1\".");
                set1.Remove("1");
                Console.WriteLine("Items from set1: ");
                set1.Show();

                Console.WriteLine(dash_50);
                Console.WriteLine("Adding element \"Somebody\".");
                set1.Add("Somebody");
                Console.WriteLine("Items from set1: ");
                set1.Show();

                Console.WriteLine(dash_50);
                Console.WriteLine("Find elements \"1\" and \"Somebody\".");
                set1.Find("1");
                set1.Find("Somebody");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(dash_50);
                var set_from_file = new Set<string>() { };
                Console.WriteLine("Reading set from file_in.txt.");
                FileStream.ReadFile(set_from_file);
                set_from_file.Show();
                Console.WriteLine("Deleting element \"Venom\".");
                set_from_file.Remove("Venom");
                Console.WriteLine("Adding element \"Peace\".");
                set_from_file.Add("Peace");
                Console.WriteLine("Write set in file_out.txt.");
                FileStream.WriteToFile(set_from_file);
                set_from_file.Show();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(dash_50);
                Console.WriteLine("Create set \"plants\" with generic parameter class.");
                var plants = new Set<Plants>() { };
                plants.Add(new Flower());
                plants.Add(new Bush());
                plants.Show();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(dash_50);
                Console.WriteLine("Adding element \"Exception\".");
                set1.Add("Exception");

            }

            catch (TooManyElementsException ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                Console.WriteLine("THE END!!!");
            }


        }
    }
}