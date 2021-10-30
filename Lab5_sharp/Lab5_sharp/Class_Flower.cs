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
            public string ColorDef;

            public FlowerColor(string color)
            {
                ColorDef = color;
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
            PriceFl = price;
            ColorFl = color;
        }
    
    }
}
