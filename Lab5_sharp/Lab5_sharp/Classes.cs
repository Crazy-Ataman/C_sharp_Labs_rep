using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5_6_7_sharp
{
    internal class Printer 
    {
        public void IAmPrinting(Plants obj) =>
            Console.WriteLine($"{obj}");
    }
    internal abstract class Plants : IGrowing
    {
        public string ColorFl { get; set; }

        public int PriceFl { get; set; }
        public string Country { get; }

        protected Plants(string country) => Country = country;

        public Plants() { }

        public virtual void Grow()
        {
            Console.WriteLine($"I am a small plant, growing in height!");
            Console.WriteLine("I grew 10 mm!");
        }

        public abstract void Print();

        public override string ToString() => GetType().Name;

        public override int GetHashCode() => new Random().Next(0, 100) % 10;
    }

    internal class Bush : Plants
    {
        public float Length { get; }
        private int Quantity { get; }

        public Bush(string country, int quantity, float length)
        : base(country)
        {
            Quantity = quantity;
            Length = length;
        }
        public override void Grow()
        {
            Console.WriteLine($"I am a small bush, growing in height!");
            Console.WriteLine($"My height now is {Length}.");
            Console.WriteLine("I grew 15 mm!");
        }

        public override void Print() =>
            Console.WriteLine($"Bushes\nCountry: {Country}\nLength: {Length}m\n" +
                              $"Quantity: {Quantity}\n");

        public override string ToString() => $"Name: {GetType()}\nQuantity: {Quantity}\n";
    }
    internal partial class Flower : Plants
    { 
        public int Price { get; }

        public float Length { get; }

        public Flower(string country,
           int price,
           float length,
           Color color)
        : base(country)
        {
            Price = price;
            Length = length;
            ColorDef = color;
        }

        public override void Grow()
        {
            Console.WriteLine($"I am a small flower with {ColorDef} petals, growing in height!");
            Console.WriteLine($"My height now is {Length} m and my price is {Price}$.");
            Console.WriteLine("I grew 15 mm!");
        }

        public override void Print() =>
            Console.WriteLine($"Flowers\nCountry: {Country}\nPrice: {Price}$\n" +
                              $"Color of petals: {ColorDef}\n");

    }
    internal class Rose : Flower
    {
        private bool IsHybrid { get; }
        public Rose(string country,
            int price,
            float length,
            Color color,
            bool IsHybrid)
        : base(country, price, length, color) => this.IsHybrid = IsHybrid;

        public override void Grow()
        {
            Console.WriteLine($"I am a small rose with {ColorDef} petals, growing in height!");
            Console.WriteLine($"My height now is {Length} m and my price is {Price}$.");
            Console.WriteLine("I grew 9 mm!");
        }

        public override void Print() =>
            Console.WriteLine($"Roses\nCountry: {Country}\nPrice: {Price}$\n" +
                              $"Color of petals: {ColorDef}\nHybrid: {IsHybrid}\n");
    }
    internal class Gladiolus : Flower
    {
        private bool IsBulb { get; }
        public Gladiolus(string country,
            int price,
            float length,
            Color color,
            bool IsBulb)
        : base(country, price, length, color) => this.IsBulb = IsBulb;

        public override void Grow()
        {
            Console.WriteLine($"I am a small gladiolus with {ColorDef} petals, growing in height!");
            Console.WriteLine($"My height now is {Length} m and my price is {Price}$.");
            Console.WriteLine("I grew 25 mm!");
        }

        public override void Print() =>
            Console.WriteLine($"Gladioli\nCountry: {Country}\nPrice: {Price}$\n" +
                              $"Color of petals: {ColorDef}\nBulb: {IsBulb}\n");
    }
    internal class Cactus : Plants, IGrowing
    {
        private float Length { get; }

        private bool IsEdible { get; }

        public Cactus(string country,
           float length,
           bool IsEdible)
        : base(country)
        {
            Length = length;
            this.IsEdible = IsEdible;
        }

        public override void Grow()
        {
            Console.WriteLine($"I am a small cactus, growing in desert!");
            Console.WriteLine($"My height now is {Length} m.");
            Console.WriteLine("I grew 2 mm!");
        }

        public override void Print() =>
            Console.WriteLine($"Cactus\nCountry: {Country}\n" +
                $"Edible: {IsEdible}\n");

        void IGrowing.Print() =>
            Console.WriteLine($"[Interface] Cactus\nCountry: {Country}\n" +
                $"Edible: {IsEdible}\n");
    }
    sealed internal class Paper : Plants
    {
       public int Height { get; }
       public int Width { get; }
       public Paper(string country, int height, int width)
       : base(country)
        {
            Height = height;
            Width = width;
        }
        internal void Cut() => Console.WriteLine("Cutting paper... Crght... Crght...");
        public override string ToString() => $"Name: {GetType()}\nCountry: {Country}\n" +
            $"Height: {Height}mm\nWidth: {Width}mm\n";

        public override void Print() =>
           Console.WriteLine($"Paper\nCountry: {Country}\n");
    }
    internal class Bouquet : Flower
    {
        private string Flowers { get; }

        public Bouquet(string country,
           int price,
           float length,
           Color color,
           string flowers)
       : base(country, price, length, color) => Flowers = flowers;

        public override void Print() =>
            Console.WriteLine($"Bouquet\nCountry: {Country}\nPrice: {Price}$\n" +
                              $"Color of petals: {ColorDef}\nFlowers: {Flowers}\n");
    }

}
