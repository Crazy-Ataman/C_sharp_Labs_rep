using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab10_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            MyHashtable myhashtable = new();
            myhashtable.Add("first_key", "first_value");
            myhashtable.Add("second_key", "second_value");
            myhashtable.Add("third_key", "third_value");
            myhashtable.ShowMyHashTable();
            Console.WriteLine("-------------------------------------------------------");

            myhashtable.Delete("first_key");
            Console.WriteLine("Deleting first_key...");
            myhashtable.ShowMyHashTable();
            Console.WriteLine("-------------------------------------------------------");

            if (myhashtable.Search("first_key") != null)
            {
                Console.WriteLine("The key \"first_key\" is found.");
            }
            else
            {
                Console.WriteLine("The key \"first_key\" is not found.");
            }
            Console.WriteLine("-------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;
            MyHashtable my_hashtable_with_worker = new();
            my_hashtable_with_worker.Add(new Worker("Petya", "Professional driver"));
            my_hashtable_with_worker.Add(new Worker("Vova", "Police officer"));
            my_hashtable_with_worker.Add(new Worker("Nastya", "Bookkeeper"));
            my_hashtable_with_worker.Add(new Worker("Mark", "Programmer"));
            my_hashtable_with_worker.ShowMyHashTable();
            Console.WriteLine("-------------------------------------------------------");

            my_hashtable_with_worker.Delete("Vova");
            Console.WriteLine("Deleting Vova...");
            my_hashtable_with_worker.ShowMyHashTable();
            Console.WriteLine("-------------------------------------------------------");

            if (my_hashtable_with_worker.Search("Petya") != null)
            {
                Console.WriteLine("The key \"Petya\" is found.");
            }
            else
            {
                Console.WriteLine("The key \"Petya\" is not found.");
            }
            Console.WriteLine("-------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.White;
            Hashtable defaulthashtable = new();
            defaulthashtable.Add("first_key", "first_value");
            defaulthashtable.Add("second_key", "second_value");
            defaulthashtable.Add("thrid_key", "third_value");
            // Counting the collection of keys 
            ICollection keys = defaulthashtable.Keys;

            Console.WriteLine("Default Hashtable:");
            foreach (string s in keys)
            {
                Console.WriteLine("\tKey: "+ s + ", Value: " + defaulthashtable[s]);
            }
            Console.WriteLine("-------------------------------------------------------");

            if (defaulthashtable.Contains("second_key"))
            {
                Console.WriteLine("The key \"second_key\" is found.");
            }
            else
            {
                Console.WriteLine("The key \"second_key\" is not found.");
            }
            Console.WriteLine("-------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Green;
            ObservableCollection<Worker> obscoll = new();
            obscoll.CollectionChanged += Notify;
            Worker worker_1 = new Worker("Engineer");
            Worker worker_2 = new Worker("Driver");
            Worker worker_3 = new Worker("Cook");
            obscoll.Add(worker_1);
            obscoll.Add(worker_2);
            obscoll.Add(worker_3);
            obscoll.Remove(worker_1);

            Console.WriteLine();
            Console.WriteLine("Observable collection:   ");
            foreach (Worker x in obscoll)
            {
                Console.WriteLine("\t" + x.Specialized + "   ");
            }
        }

        private static void Notify(object sender, NotifyCollectionChangedEventArgs x)
        {
            switch(x.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Worker newWorker = x.NewItems[0] as Worker;
                    Console.WriteLine($"Added {newWorker.Specialized}");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Worker oldWorker = x.OldItems[0] as Worker;
                    Console.WriteLine($"Deleted {oldWorker.Specialized}");
                    break;
            }
        }
    }
}
