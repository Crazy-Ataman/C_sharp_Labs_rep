using System;
using System.Collections;

namespace Lab3_sharp
{
    public partial class Customer : IComparable
    {   // The IComparable interface is used to sort sets of complex objects.
        // : IComparable - need for function IComparable.CompareTo(object obj), otherwise don't work.
        // Fields
        private const int max_id = 99_999_999;
        private const int max_cards = 9_999_999;
        private static readonly string country;
        private static int count_of_cards;

        private int id;
        private string surname;
        private string name;
        private string patronymic;
        private string address;
        private int card_number;
        private int balance_of_card;

        // Properties 
        public int Id
        {
            get => id;
            set
            {
                if (value >= max_id || value <= 0)
                    throw new Exception("Incorrect ID!");
                else
                    id = value;
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }
        public string Patronymic
        {
            get => patronymic;
            set
            {
                patronymic = value;
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
            }
        }
        public int Card_number
        {
            get => card_number;
            private set
            {
                card_number = value;
            }
        }
        public int Balance
        {
            get => balance_of_card;
            set
            {
                balance_of_card = value;
            }
        }

        // Constructors 
        static Customer()
        {   // Static constructotr
            Console.WriteLine("I am the static constructor of customers.");
            country = "China";
            count_of_cards = 0;
        }
        public Customer()
        {   
            id = 99_999_998;
            count_of_cards++;
        }
        private Customer(int id)
        {
            this.id = id;
            count_of_cards++;
        }
        public Customer(string surname, string name, string patronymic, string address, int card_number, int balance_of_card)
        {   // Constructor without id
            if (card_number < max_cards && card_number > 0)
            {
                this.surname = surname;
                this.name = name;
                this.patronymic = patronymic;
                this.address = address;
                this.card_number = card_number;
                this.balance_of_card = balance_of_card;
                count_of_cards++;
            }
            else
                throw new Exception("Incorrect input!");
        }
        public Customer(int id, string surname, string name, string patronymic, string address, int card_number, int balance_of_card)
        {   // Constructor with id
            if (card_number < max_cards && card_number > 0)
            {
                this.id = id;
                this.surname = surname;
                this.name = name;
                this.patronymic = patronymic;
                this.address = address;
                this.card_number = card_number;
                this.balance_of_card = balance_of_card;
                count_of_cards++;
            }
            else
                throw new Exception("Incorrect input!");
        }

        // Methods
        public void Increase_balance(ref int balance_of_card, int enrollment)
        {   // Increase balance by enrollment.
            balance_of_card += enrollment;
        }
        public void Decrease_balance(ref int balance_of_card, int enrollment)
        {   // Decrease balance by enrollment.
            balance_of_card -= enrollment;
        }
        public static void Change_customer(out string new_surname_out, string new_surname)
        {   // Change customer's surname.
            new_surname_out = new_surname;
        }
        public void Show()
        {   // Show all customers.
            Console.WriteLine(this.ToString());
        }
        //Implement IComparable CompareTo method - provide default sort order.
        int IComparable.CompareTo(object obj)
        {   // Compare one surname with another surname.
            Customer c = (Customer)obj;
            // String.Compare - method is designed primarily for use in sorting or alphabetizing operations. Not for compare two string! 
            return String.Compare(this.surname, c.surname);
        }
    }
}