using System;

namespace Lab14_sharp
{
    [Serializable]
    public class Plant
    {
        public Plant() { }
        public string Name { get; set; }
        public float Length { get; set; }

        [NonSerialized]
        public int Price;

        public Plant(string name, float length, int price)
        {
            Name = name;
            Length = length;
            this.Price = price;
        }

        public override string ToString() => $"Name: {Name}, length: {Length}";
    }
}
