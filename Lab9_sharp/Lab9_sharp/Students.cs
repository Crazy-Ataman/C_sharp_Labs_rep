using System;

namespace Lab9_sharp
{
    public class Students
    {
        private string Name { get; set; }

        public Students(string name) => Name = name;

        public void GossipAboutRaise()
            => Console.WriteLine($"[{Name}] You heard?! Our director got a raise. About five hundred bucks!");

        public void GossipAboutFine()
            => Console.WriteLine($"[{Name}] You heard?! Our director got a fine. About three hundred bucks!");

    }
}
