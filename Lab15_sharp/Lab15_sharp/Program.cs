using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Lab15_sharp
{
    internal class Program
    {
        public static bool IsPrime(int number)
        {
            switch (number)
            {
                case <= 1:
                    return false;
                case 2:
                    return true;
            }

            if (number % 2 == 0)
                return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (var i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            var allProcess = Process.GetProcesses();
            Console.WriteLine($"{"ID", -11} {"Name", -34} {"Priority", -40}");
            Console.WriteLine(new string('_', 55));
            foreach (var proc in allProcess)
            {
                Console.WriteLine("{0, -9} {1, -36} {2, -70}",
                    "|" + $"{proc.Id}".PadRight(9) + "|", 
                    $"{proc.ProcessName}".PadRight(36) + "|", 
                    $"{proc.BasePriority}".PadRight(2) + "|");

                // proc.StartTime - protected by some processes. Usually svhost, windows and etc.
                // try and catch need to prevent unhandle exception
                //try
                //{
                //    Console.WriteLine($"ID: {proc.Id}\tStart time: {proc.StartTime}\tName: {proc.ProcessName} \tPriority: {proc.BasePriority}");
                //}

                //catch
                //{
                //    Console.WriteLine($"Access denied {proc.ProcessName}");
                //}
            }
            Console.WriteLine(new string('-', 55));

            Console.ForegroundColor = ConsoleColor.Green;

            AppDomain originalDomain = AppDomain.CurrentDomain;
            // Friendly in this context is understandably.
            Console.WriteLine($"Name: {originalDomain.FriendlyName}");
            Console.WriteLine($"Details: {originalDomain.SetupInformation}");
            Console.WriteLine($"Base directory: {originalDomain.BaseDirectory}");
            Console.WriteLine($"Assemblies: ");
            originalDomain.GetAssemblies().ToList().ForEach(x => Console.WriteLine($"\t{x.FullName}"));

            // .NET FrameWork, not .NET Core
            AppDomain newDomain = AppDomain.CreateDomain("New Domain");
            newDomain.Load(Assembly.GetExecutingAssembly().FullName);

            Console.WriteLine($"\nName: {newDomain.FriendlyName}");
            Console.WriteLine($"Details: {newDomain.SetupInformation}");
            Console.WriteLine($"Base directory: {newDomain.BaseDirectory}");
            Console.WriteLine($"Assemblies: ");
            newDomain.GetAssemblies().ToList().ForEach(x => Console.WriteLine($"\t{x.FullName}"));

            AppDomain.Unload(newDomain);

            // Exception - newDomain unloaded, otherwise - something go wrong.
            //Console.WriteLine($"\nName: {newDomain.FriendlyName}");


            Console.Write("\nInput number for count primes number: ");
            var n = int.Parse(Console.ReadLine());
            Thread numbersThread = new Thread(()=>
            {
                Thread.CurrentThread.Name = "myThread";
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                Thread.Sleep(3000);
                var primes = new List<int>();
                for (var i = 1; i <= n; i++)
                {
                    if (IsPrime(i))
                    {
                        primes.Add(i);
                    }
                }
                Console.WriteLine(new string('-', 55));
                Console.WriteLine($"Status: {Thread.CurrentThread.ThreadState}");
                Console.WriteLine($"Name: {Thread.CurrentThread.Name}");
                Console.WriteLine($"Priority: {Thread.CurrentThread.Priority}");
                Console.WriteLine($"ID: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine(new string('-', 55));
                using var writer = new StreamWriter(@"..\..\..\primes.txt");
                writer.WriteLine(string.Join(", ", primes));
                Console.WriteLine(string.Join(", ", primes));
            });

           
            numbersThread.Start();
            Thread.Sleep(1000);
            Console.WriteLine(new string('-', 55));
            Console.WriteLine($"Status: {numbersThread.ThreadState}");
            Console.WriteLine($"Name: {numbersThread.Name}");
            Console.WriteLine($"Priority: {numbersThread.Priority}");
            Console.WriteLine($"ID: {numbersThread.ManagedThreadId}");
            Console.WriteLine(new string('-', 55));

            Console.Write("\n");

            Thread.Sleep(2300);
            Console.WriteLine(new string('-', 55));
            Console.WriteLine($"Status: {numbersThread.ThreadState}");
            Console.WriteLine($"Name: {numbersThread.Name}");
            // You can't to get priority from aborted thread.
            //Console.WriteLine($"Priority: {numbersThread.Priority}");
            Console.WriteLine($"ID: {numbersThread.ManagedThreadId}");
            Console.WriteLine(new string('-', 55));

            Console.Write("Input number: ");
            n = int.Parse(Console.ReadLine());
            OddAndEven.SingleThread(n);
            Console.WriteLine("At first even numbers, after that odd numbers.");

            Thread.Sleep(5000);
            Console.WriteLine("\nEven, odd, even, odd...");
            OddAndEven.Together(n);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
            TimerCallback timerCallback = new TimerCallback(CurrentTime);
            Timer timer = new Timer(timerCallback, null, 0, 1000);
            Thread.Sleep(3000);
            void CurrentTime(object obj)
            {
                Console.WriteLine(DateTime.Now);
            }
        }
    }
}
