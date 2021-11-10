using System;

namespace Lab11_sharp
{
    internal class Customer : IComparable
    {
        private const int max_id = 99_999_999;
        private const int max_cards = 9_999_999;

        public int id;
        public string surname;
        public string name;
        public string patronymic;
        public string address;
        public int card_number;
        public int balance_of_card;

        public Customer(int id, string surname, string name, string patronymic, string address, int card_number, int balance_of_card)
        {
            if (card_number < max_cards && card_number > 0)
            {
                this.id = id;
                this.surname = surname;
                this.name = name;
                this.patronymic = patronymic;
                this.address = address;
                this.card_number = card_number;
                this.balance_of_card = balance_of_card;
            }
            else
                throw new Exception("Incorrect input!");
        }

        public override string ToString()
        {
            return $"ID: {id}\n" +
                $"Surname: {surname}\n" +
                $"Name: {name}\n" +
                $"Patronymic: {patronymic}\n" +
                $"Address: {address}\n" +
                $"Card number: {card_number}\n" +
                $"Balance: {balance_of_card}$\n";
        }

        public void Show()
        {
            Console.WriteLine(ToString());
        }

        int IComparable.CompareTo(object obj)
        {   // Compare one surname with another surname.
            Customer c = (Customer)obj;
            // String.Compare - method is designed primarily for use in sorting or alphabetizing operations. Not for compare two string! 
            return String.Compare(this.surname, c.surname);
        }
    }
}
