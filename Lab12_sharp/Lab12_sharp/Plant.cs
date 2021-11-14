using System;

namespace Lab12_sharp
{
    class Plant
    {
        private string _name;
        private string _type;

        public string Name => _name;

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        private Plant() 
        {

        }

        public Plant(string name, string type) 
        {
            _name = name;
            _type = type;
        }





    }
}
