using System;

namespace Lab11_sharp
{
    class Person
    {
        public string Name { get; set; }
        public Customer Customer { get; set; }

        public Person(string Name, Customer Customer)
        {
            this.Name = Name;
            this.Customer = Customer;
        }
    }
}
