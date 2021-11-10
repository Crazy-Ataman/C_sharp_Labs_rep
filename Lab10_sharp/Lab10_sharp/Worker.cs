using System;

namespace Lab10_sharp
{
    public class Worker
    {
        private string _name;

        public string Name
        {
            get => _name;
        }

        private string _specialized;

        public string Specialized
        {
            get => _specialized;
        }

        public Worker(string specialized)
        {
            _specialized = specialized;
        }

        public Worker(string name, string specialized)
        {
            _name = name;
            _specialized = specialized;
        }

        public override string ToString() => "Worker";
    }
}
