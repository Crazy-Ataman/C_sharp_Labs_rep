using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_6_7_sharp
{

    partial class Flower : IComparable
    {
        struct FlowerColor
        {
            public string Color;

            public FlowerColor(string color)
            {
                Color = color;
            }
        }

        public Color ColorDef { get; }

        public enum Color
        {
            Red,
            Blue,
            Green,
            Purple,
            Yellow,
            White
        }

        public int CompareTo(object obj)
        {
            Flower flower = (Flower)obj;
            if (PriceFl > flower.PriceFl) return 1;
            if (PriceFl < flower.PriceFl) return -1;
            return 0;
        }
        public Flower(int price, string color)
        {
            //if (Price < 0)
            //    throw new FlowerException("Стоимость не может быть < 0", Price);
            PriceFl = price;
            ColorFl = color;
        }

        private FlowerColor objColor;
        private FlowerColor redColor = new FlowerColor("Red");
        private FlowerColor blueColor = new FlowerColor("Blue");
        private FlowerColor greenColor = new FlowerColor("Green");
        private FlowerColor purpleColor = new FlowerColor("Purple");
        private FlowerColor yellowColor = new FlowerColor("Yellow");
        private FlowerColor whiteColor = new FlowerColor("White");

        public void ChooseColor(Color num)
        {
            switch (num)
            {
                case Color.Red:                 
                    objColor = redColor;
                    Console.WriteLine("Your choose Red.");
                    break;
                case Color.Blue:                 
                    objColor = blueColor;
                    Console.WriteLine("Your choose Blue.");
                    break;
                case Color.Green:                
                    objColor = greenColor;
                    Console.WriteLine("Your choose Green.");
                    break;
                case Color.Purple:
                    objColor = purpleColor;
                    Console.WriteLine("Your choose Purple.");
                    break;
                case Color.Yellow:
                    objColor = yellowColor;
                    Console.WriteLine("Your choose Yellow.");
                    break;
                case Color.White:
                    objColor = whiteColor;
                    Console.WriteLine("Your choose White.");
                    break;
                default:
                    Console.WriteLine("Unknown color. Installed Red.");
                    objColor = redColor;
                    break;
            }
        }


    }
}
