using System;

namespace Lab11_sharp
{
    class Car
    {
        public string Automobile { get; set; }
        public Customer Customer { get; set; }

        public Car(string Automobile, Customer Customer)
        {
            this.Automobile = Automobile;
            this.Customer = Customer;
        }
    }
}
