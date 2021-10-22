using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_6_7_sharp
{
    class JsonClass
    {
        public string Country { get; }

        public float Length { get; }

        public int Price { get; }

        public JsonClass(string country, float length, int price)
        {
            Country = country;
            Length = length;
            Price = price;
        }

        public void Print() => Console.WriteLine($"Country: {Country}\nLength: {Length} mm\nPrice: {Price}$");
    }
}
