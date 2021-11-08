using System;

namespace Lab9_sharp
{
    class Director
    {
        public delegate void DirectorHandler();
        public event DirectorHandler Raise;
        public event DirectorHandler Fine;

        public string Name { get; set; }
        public int Money { get; set; }
        public int FineCounter { get; set; } = 0;

        public Director(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public void ShowInfo() 
            => Console.WriteLine($"{Name} has money {Money}$. The number of fines: {FineCounter}.");

        public void RaiseDirector()
        {
            Money += 500;
            Raise?.Invoke();
        }

        public void GetFine()
        {
            Money -= 300;
            FineCounter++;
            Fine?.Invoke();
        }
    }
}
