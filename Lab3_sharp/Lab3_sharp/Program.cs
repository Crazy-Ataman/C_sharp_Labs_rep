using System;

namespace Lab3_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = new Customer[5];
            customers[0] = new Customer(89_765_789, "Musk", "Elon", "none", "USA, Texas, Starbase", 8_123_456, 1_000_000);
            customers[1] = new Customer(99_100_000, "Dashchynksi", "Maksim", "Leonidovich", "Belarus, Minsk", 0_000_100, 99_999_999);
            customers[2] = new Customer(00_145_324, "Mozolevski", "Alexander", "Dmitrievich", "Belarus, Minsk", 0_199_613, 10_654_123);
            customers[3] = new Customer(56_129_786, "Rybkin", "Pasha", "Vikrorievich", "Russia, Moskva", 4_632_875, 152_987);
            customers[4] = new Customer(56_129_786, "Rybkin", "Pasha", "Vikrorievich", "Russia, Moskva", 4_632_875, 152_987);

            // Show all customers.
            foreach (Customer customer in customers)
                customer.Show();

            // Equal or not.
            if (customers[3].Equals(customers[4]))
                Console.WriteLine("These customers are equal.");
            else
                Console.WriteLine("These customers are NOT equal.");

            // Show all customers in alphabetical order by surname. 
            Array.Sort(customers);
            Console.WriteLine("----------SORTED ARRAY----------");
            foreach (Customer customer in customers)
                customer.Show();

            // A list of customers whose credit card number is in the specified range. 
            Console.Write("Enter a range of card numbers (start): ");
            int card_range_start = Int32.Parse(Console.ReadLine());
            Console.Write("Enter a range of card numbers (end): ");
            int card_range_end = Int32.Parse(Console.ReadLine());
            string dash_50 = new String('-', 50);
            string dash_110 = new String('-', 110);
            Console.WriteLine(dash_50 + "The list of cards" + dash_50);
            foreach (Customer customer in customers)
            {
                if (customer.Card_number > card_range_start && customer.Card_number < card_range_end)
                    customer.Show();
            }
            Console.WriteLine(dash_110);

            // Increase and decrease balance.
            Customer rybkin = customers[4];
            int balance_rybkin = rybkin.Balance;
            rybkin.Show();
            Console.Write("Amount enrollment: ");
            int enrollment = Int32.Parse(Console.ReadLine());
            rybkin.IncreaseBalance(ref balance_rybkin, enrollment);
            rybkin.Balance = balance_rybkin;
            rybkin.Show();
            Console.WriteLine(dash_110);
            Console.Write("Amount withdraw: ");
            enrollment = Int32.Parse(Console.ReadLine());
            rybkin.DecreaseBalance(ref balance_rybkin, enrollment);
            rybkin.Balance = balance_rybkin;
            rybkin.Show();
            Console.WriteLine(dash_110);

            // Change customer's surname.
            string new_surname;
            //rybkin.Change_customer(out new_surname, "Griboedov"); // Function Change_customer is not static.
            Customer.ChangeCustomer(out new_surname, "Griboedov"); // Requires clarification if function Change_customer is static.
            rybkin.Surname = new_surname;
            rybkin.Show();
            Console.WriteLine(dash_110);

            // Amount of cards.
            rybkin.ShowCountOfCards();

            // Anonymous type.
            var anonim = new { Surname = "NO_INFO", Name = "Inkognito" };
            Console.WriteLine(dash_50 + "ANONYMOUS" + dash_50 +
                $"\nSurname: {anonim.Surname}" +
                $"\nName: {anonim.Name}\n");

            // Example of error.
            try
            {
                Console.WriteLine("Example of error.");
                Customer example_of_error = new Customer();
                example_of_error.Id = -1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
