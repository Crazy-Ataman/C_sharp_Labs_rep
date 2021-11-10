using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab11_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = new string[]
             {
                "January",  // 0
                "February", // 1
                "March",    // 2
                "April",    // 3
                "May",      // 4
                "June",     // 5
                "July",     // 6
                "August",   // 7
                "September",// 8
                "October",  // 9
                "November", // 10
                "December"  // 11
             };

            // The request that selects a sequence of months with a string length of n.
            var monts_ex_1 = months.Where(n => n.Length == 4);
            // The request returning only summer and winter months.
            // i - used as index (n[i])
            var monts_ex_2 = months.Where((n, i) => (i < 2) || (i > 4 && i < 8) || (i == 11));
            // The request to display months in alphabetical order. 
            // OrderBy - orders elements in ascending order 
            var monts_ex_3 = months.OrderBy(x => x);
            // The request that counts months containing the letter "u" and the length of the name is at least 4. 
            var monts_ex_4 = months.Where(x => x.Contains("u") && x.Length >= 4);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The request that selects a sequence of months with a string length of n.");
            foreach (var i in monts_ex_1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("___________________________________________________________________");

            Console.WriteLine("The request returning only summer and winter months.");
            foreach (var i in monts_ex_2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("___________________________________________________________________");

            Console.WriteLine("The request to display months in alphabetical order.");
            foreach (var i in monts_ex_3)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("___________________________________________________________________");

            Console.WriteLine("The request that counts months containing the letter \"u\" and the length of the name is at least 4.");
            foreach (var i in monts_ex_4)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("###################################################################\n");

            List<Customer> customers = new();
            customers.Add(new Customer(98_593_240, "Mozolevsky", "Alexander", "Dmitrievich", "Minsk", 1_000_000, 2_000_000_000));
            customers.Add(new Customer(1_000_000, "Dashchynski ", "Maksim", "Leonidovich", "Minsk", 7_000_000, 1_999_999_999));
            customers.Add(new Customer(78_363_194, "Elon", "Musk", "none", "Texas", 6_698_268, 199_567_000));
            customers.Add(new Customer(66_666_666, "none", "Satana", "none", "Hell", 6_666_666, 666_666_666));
            customers.Add(new Customer(33_333_333, "Newell", "Gabe", "none", "New York", 3_333_333, 333_333_333));
            customers.Add(new Customer(12_457_090, "Rybkin", "Pavel", "none", "Paris", 2_043_129, 789));
            customers.Add(new Customer(33_333_333, "Pypkin", "Popa", "Popivich", "Africa", 1, 0));
            customers.Add(new Customer(11_545_654, "Alice", "Gold", "none", "Monreal", 4_331_154, 1_000_000));
            customers.Add(new Customer(4_666_513, "Kotova", "Kasya", "none", "Madrid", 1_747_923, 999));
            customers.Add(new Customer(8_525_009, "Brown", "Leva", "none", "Moskva", 4_636_176, 5000));

            // The list of buyers in alphabetical order.
            var customers_ex_1 = customers.OrderBy(x => x);
            // The maximum customer (criterion: maximum account amount).
            var customers_ex_3 = customers.OrderByDescending(x => x.balance_of_card).Take(1);
            // The first five customers with the maximum amount on the card.
            var customers_ex_4 = customers.OrderByDescending(x => x.balance_of_card).Take(5);

            string dash_110 = new String('-', 110);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(dash_110);
            Console.WriteLine("The list of buyers in alphabetical order.");
            foreach (var i in customers_ex_1)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine(dash_110);
            Console.WriteLine();
            // The list of customers whose credit card number is in the specified interval.
            Console.WriteLine("The list of customers whose credit card number is in the specified interval.");
            Console.Write("Enter a range of card numbers (start): ");
            int card_range_start = Int32.Parse(Console.ReadLine());
            Console.Write("Enter a range of card numbers (end): ");
            int card_range_end = Int32.Parse(Console.ReadLine());
            string dash_50 = new String('-', 50);
            Console.WriteLine(dash_50 + "The list of cards" + dash_50);
            foreach (Customer customer in customers)
            {
                if (customer.card_number > card_range_start && customer.card_number < card_range_end)
                    customer.Show();
            }
            Console.WriteLine(dash_110);
            Console.WriteLine("The maximum customer (criterion: maximum account amount).");
            foreach (var i in customers_ex_3)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine(dash_110);
            Console.WriteLine("The first five customers with the maximum amount on the card.");
            foreach (var i in customers_ex_4)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n");

            // The request consisting of 5 operators from different categories: conditions, projections, ordering, grouping, aggregation, quantifiers and splitting. 
            var five_operators = customers.Where(x => x.balance_of_card <= 1_000_000)
                .Skip(1)
                .OrderByDescending(x => x.card_number)
                .Where(x => x.id > 5_000_000)
                .Take(2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Five operators.\n");
            foreach (var i in five_operators)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("*******************************************************************\n");

            Person person_1 = new Person("Alexander", customers[0]);
            Person person_2 = new Person("Elon", customers[2]);
            Person person_3 = new Person("Alice", customers[7]);
            Person person_4 = new Person("Maks", customers[1]);
            List<Person> people = new List<Person>() { person_1, person_2, person_3, person_4 };
            var last = people.Join(customers,
                p => p.Customer,
                c => c,
                (p, c) => new { Name = p.Name, ID = c.id, Address = c.address }
                );
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Join request\n");
            foreach (var i in last)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
