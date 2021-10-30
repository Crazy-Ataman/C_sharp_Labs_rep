using Lab5_6_7_sharp.Exceptions;
using System;
using System.Collections.Generic;

namespace Lab5_6_7_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---------------- 5 ----------------
            Printer printer = new();

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
                    5.4f,
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
            listOfPlants[6].Print();
            // Calling Print() in interface IGrowing
            (listOfPlants[6] as IGrowing)?.Print();

            Console.WriteLine("________________________________");
            foreach (var plant in listOfPlants)
            {
                (plant as Rose)?.Grow();
                (plant as Paper)?.Cut();
            }

            Console.WriteLine("________________________________");
            Console.WriteLine("Call IAmPrinting:");
            foreach (var plant in listOfPlants)
            {
                printer.IAmPrinting(plant);
            }

            // ---------------- 6 ----------------

            Console.WriteLine("________________________________");
            CollectionType<string> example = new();
            IGeneral<string> general;
            example.Add("Doka");
            example.Add("LoL");
            example.Add("WoT");
            general = example;
            general.Show();

            try
            {
                Flower flower = new Flower(50, "Red");
                Flower flower1 = new Flower(20, "Green");
                Flower flower2 = new Flower(30, "Blue");
                Bouquete bouquete = new Bouquete();
                bouquete.Add(flower);
                bouquete.Add(flower1);
                bouquete.Add(flower2);

                Console.WriteLine("---------------Before sorting--------------");
                foreach (Flower item in bouquete.BouqWithFl)
                {
                    Console.WriteLine(item.PriceFl + " " + item.ColorFl);
                }
                Console.WriteLine("The total price of the bouquet : " + bouquete.GetPrice());
                Console.WriteLine("------------After sorting by price------------");
                BouqContr.SortFlowers(bouquete);
                foreach (Flower item in bouquete.BouqWithFl)
                {
                    Console.WriteLine(item.PriceFl + " " + item.ColorFl);
                }

                // Find flower by color
                BouqContr.FindByColor(bouquete, "Red");

                // Read a file txt
                Console.WriteLine("________________________________");
                Console.WriteLine("Reading a file...");
                var bouqfile = BouqContr.ParseFileTXT();
                foreach (Flower item in bouqfile.BouqWithFl)
                {
                    Console.WriteLine(item.PriceFl + " " + item.ColorFl);
                }

                //Read JSON file
                Console.WriteLine("________________________________");
                Console.WriteLine("Reading a JSON file...");
                var jsonclass = BouqContr.ParseFileJSON();
                foreach (JsonClass item in jsonclass)
                {
                    item.Print();
                }

                // ---------------- 7 ----------------

                Console.WriteLine("________________________________");
                //Console.WriteLine("Try to delete item with negative index.");
                //example.Delete(-1);
                //Console.WriteLine("Try to delete item with too huge index.");
                //example.Delete(99999999);
                Console.WriteLine("Try to delete item with incorrect index.");
                bouquete.Delete(10);
            }
            catch (CollectionExceptions ex)
            {
                Console.WriteLine(ex);
                Logger.WriteLog(ex);
            }
            catch (ControllerExceptions ex)
            {
                Console.WriteLine(ex);
                Logger.WriteLog(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Logger.WriteLog(ex);
            }
            finally
            {
                Console.WriteLine("\nThe end.");
            }

        }
    }
}
