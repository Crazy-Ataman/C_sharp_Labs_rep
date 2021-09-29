using System;

namespace Lab3_sharp
{
    public partial class Customer
    {
        public void ShowCountOfCards()
        {
            Console.WriteLine($"Current number of cards: {count_of_cards}");
        }
        // override - redefine a method in a inheritor class 
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            Customer customer = obj as Customer;
            if (customer == null)
                return false;
            return customer.id == this.id;
        }

        public override int GetHashCode()
        {
            if (this.id == 99_999_998)
                return 0;
            else
                return id % 10;
        }

        public override string ToString()
        {
            return $"ID: {this.id}\n" +
                $"Surname: {this.surname}\n" +
                $"Name: {this.name}\n" +
                $"Patronymic: {this.patronymic}\n" +
                $"Address: {this.address}\n" +
                $"Card number: {this.card_number}\n" +
                $"Balance of card: {this.balance_of_card}$\n";
        }
    }
}