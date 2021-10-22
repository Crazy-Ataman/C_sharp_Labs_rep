using Lab5_6_7_sharp.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Lab5_6_7_sharp
{
    class PriceComp : IComparable<Flower>
    {
        public int Compare(Flower x, Flower y)
        {
            if (x.PriceFl > y.PriceFl)
            {
                return 1;
            }
            else if (x.PriceFl < y.PriceFl)
            {
                return -1;
            }

            return 0;
        }

        public int CompareTo([AllowNull] Flower other)
        {
            throw new NotImplementedException();
        }
    }
    class Bouquete
    {
        public List<Flower> BouqWithFl;

        public Bouquete()
        {
            BouqWithFl = new List<Flower>();
        }
        public void Delete(int index)
        {
            try
            {
                BouqWithFl.RemoveAt(index);
            }
            catch
            {
                throw new ControllerExceptions($"Out of bounds.");
            }
        }
        public void Add(Flower item)
        {
            BouqWithFl.Add(item);
        }

        public int GetPrice()
        {
            int result = 0;
            foreach (Flower item in BouqWithFl)
            {
                result += item.PriceFl;
            }
            return result;
        }
    }

    class BouqContr
    {
        public static void SortFlowers(Bouquete b)
        {
            b.BouqWithFl.Sort();
        }

        public static void FindByColor(Bouquete b, string color)
        {
            foreach (Flower item in b.BouqWithFl)
            {
                if (item.ColorFl == color)
                {
                    Console.WriteLine($"The flower with color {color} was found. The price: {item.PriceFl}");
                }
            }
        }

        public static Bouquete ParseFileTXT()
        {
            var bouqFile = new Bouquete();
            // @ - allows you not to shield characters
            // ^ - start of line
            // F - Flower, P - Price, C - Color
            // \s - space, \d - [0-9], \w - any word, + - 1 to infinity
            var regexBouq = new Regex(@"^(?<F>Flower):\s?(?<P>\d+),\s?(?<C>\w+)$");

            foreach (var el in File.ReadAllLines(@"..\..\..\6_lab.txt")) 
            {
                if (regexBouq.Match(el).Groups["F"].Value == "Flower") 
                {
                    bouqFile.Add(
                        new Flower(Convert.ToInt32(regexBouq.Match(el).Groups["P"].Value),
                        regexBouq.Match(el).Groups["C"].Value));
                }
            }
            return bouqFile;
        }

        // Deserialize - восстановления набора байтов в (десериализация) строку json в объект типа type и возвращает десериализованный объект.
        public static List<JsonClass> ParseFileJSON()
            => (List<JsonClass>)new JsonSerializer().Deserialize(
                File.OpenText(@"..\..\..\JSON_file.json"), typeof(List<JsonClass>))!;
    }
}