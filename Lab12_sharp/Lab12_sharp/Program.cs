using System;

namespace Lab12_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string dash_100 = new('-', 100);
            int i = 0;
            Plant plant = new("Rose", "Bush");
            Console.WriteLine(dash_100);
            Console.WriteLine("Ex. 1." + ++i + ": " + Reflector.GetAssemblyVersion());

            Console.WriteLine(dash_100);
            Console.WriteLine("Ex. 1." + ++i + ": " +
                (Reflector.PublicConstructor(plant) ?
                "Plant include public constructor." :
                "Plant doesn't include public constructor."));

            Console.WriteLine(dash_100);
            Console.WriteLine("Ex. 1." + ++i + ": ");
            Reflector.GetPublicMethods(plant);

            Console.WriteLine(dash_100);
            Console.WriteLine("Ex. 1." + ++i + ": ");
            Reflector.GetProperty(plant);
            Reflector.GetFields(plant);

            Console.WriteLine(dash_100);
            Console.WriteLine("Ex. 1." + ++i + ": ");
            Reflector.GetInterfaces(plant);

            Console.WriteLine(dash_100);
            Console.WriteLine("Ex. 1." + ++i + ": ");
            Reflector.InvokeFromFile();

            Console.WriteLine(dash_100);
            object obj = Reflector.Create("Oak", "Tree");
            Console.WriteLine($"Ex. 2: {(obj as Plant).Name} {(obj as Plant).Type}");
            Console.WriteLine(dash_100);
        }
    }
}
