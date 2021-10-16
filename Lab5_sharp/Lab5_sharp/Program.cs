using System;
using System.Collections.Generic;

namespace Lab5_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();

            var listOfPlants = new List<Plants>
            {
                new Flower("Poland", 
                    10, 
                    0.8f, 
                    Flower.Color.White),
                new Flower("Germany",
                    25,
                    0.2f,
                    Flower.Color.Purple),
                new Bush("Russia",
                    1000,
                    1.5f),
                new Bush("Mexico",
                    5000,
                    0.7f),
                new Rose("Russia",
                    43,
                    2f,
                    Flower.Color.Red,
                    false),
                new Gladiolus("South Africa",
                    70,
                    1.2f,
                    Flower.Color.Yellow,
                    true),
                new Cactus("USA",
                    false),
                new Paper("Italia",
                    420,
                    594),
                new Bouquet("France",
                    8,
                    0.3f,
                    Flower.Color.Red,
                    "Roses and gladioli")
            };

            foreach (var plants in listOfPlants)
            {
                plants.Print();
            }

            Console.WriteLine("________________________________");
            listOfPlants[0].Print();
            (listOfPlants[0] as IGrowing)?.Print();

            Console.WriteLine("________________________________");
            foreach (var plant in listOfPlants)
            {
                (plant as Rose)?.Grow();
                (plant as Paper)?.Grow();
            }

            Console.WriteLine("________________________________");
            foreach (var plant in listOfPlants)
            {
                printer.IAmPrinting(plant);
            }









        }
    }
}
