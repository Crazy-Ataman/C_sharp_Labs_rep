using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Lab16_sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            //Task6();
            //Task7();
            Task8();
        }

        static void Task1()
        {
            for (int i = 0; i < 5; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Task task = new Task(() => SieveEratosthenes(5000));
                // Created - the task has been initialized but has not yet been scheduled.
                Console.WriteLine($"Task1 id: {task.Id}, status: {task.Status}");
                task.Start();
                // WaitingToRun - the task has been scheduled for execution but has not yet begun executing.
                Console.WriteLine($"Task1 id: {task.Id}, status: {task.Status}");
                task.Wait();
                // RanToCompletion - the task completed execution successfully.
                Console.WriteLine($"Task1 id: {task.Id}, status: {task.Status}");
                sw.Stop();
                Console.WriteLine($"Task1 #1: {sw.ElapsedMilliseconds}ms");
                Console.WriteLine();
            }
        }

        static List<uint> SieveEratosthenes(uint n, object obj = null)
        {
            if (obj != null)
            {
                var token = (CancellationToken)obj;
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Task2 is canceled without exception.");
                    return new List<uint>();
                }
            }
            var numbers = new List<uint>();
            // Filling the list with numbers from 2 to n-1.
            // Literal u means the value is an unsigned integer.
            for (var i = 2u; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    // Remove multiples from the list.
                    numbers.Remove(numbers[i] * j);
                }
            }

            return numbers;
        }

        static void Task2()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            Task task = Task.Run(() => SieveEratosthenes(5000, token));
            try
            {
                cancelTokenSource.Cancel();
                task.Wait();
            }
            catch (Exception)
            {
                if (task.IsCanceled)
                    Console.WriteLine("Task2 is canceled with handled exception.");
            }
        }

        static void Task3()
        {
            Task<int> first = new Task<int>(() => new Random().Next(1, 9) * 100);
            Task<int> second = new Task<int>(() => new Random().Next(0, 9) * 10);
            Task<int> third = new Task<int>(() => new Random().Next(0, 9) * 3);

            first.Start();
            second.Start();
            third.Start();
            first.Wait();
            second.Wait();
            third.Wait();

            Console.WriteLine($"First number: {first.Result}\n" +
                $"Second number: {second.Result}\n" +
                $"Third number: {third.Result} ");
            Task<int> sum = new Task<int>(() => first.Result + second.Result + third.Result);
            sum.Start();
            Console.WriteLine($"Result: {first.Result} + {second.Result} + {third.Result} = {sum.Result}");
        }

        static void Task4()
        {
            Task<int> task4 = new Task<int>(() => 666 + 99 + 26);
            Task show = task4.ContinueWith(sum => Console.WriteLine($"Sum: 666 + 99 + 26 = {sum.Result}"));
            task4.Start();
            show.Wait();

            Task<double> sqrt = new Task<double>(() => Math.Sqrt(169));
            // GetAwaiter() and GetResult() are dangerous in unskilled hands.
            // Use only, when you know what you are doing.
            TaskAwaiter<double> awaiter = sqrt.GetAwaiter();
            awaiter.OnCompleted(() => Console.WriteLine($"Result: sqrt(169) = {sqrt.Result}"));
            sqrt.Start();
            sqrt.Wait();
            awaiter.GetResult();
            Thread.Sleep(10);
        }

        static void Task5()
        {
            int[] arr1 = new int[1_000_000];
            int[] arr2 = new int[1_000_000];
            int[] arr3 = new int[1_000_000];

            Stopwatch sw = new Stopwatch();
            sw.Start();
            // The method Fill get a counter from For, that is 0, 1, 2, ....
            Parallel.For(0, 1_000_000, Fill);
            sw.Stop();
            Console.WriteLine($"Parallel for: {sw.ElapsedMilliseconds}ms");

            sw.Restart();
            for (int i = 0; i < 1_000_000; i++)
            {
                arr1[i] = i;
                arr2[i] = i;
                arr3[i] = i;
            }
            sw.Stop();
            Console.WriteLine($"Normal for: {sw.ElapsedMilliseconds}ms");

            sw.Restart();
            // the first parameter represents the collection to iterate over,
            // and the second parameter is a delegate that is executed once per iteration for each collection item that is iterated over. 
            Parallel.ForEach(arr1, i => i = 1);
            Parallel.ForEach(arr2, i => i = 1);
            Parallel.ForEach(arr3, i => i = 1);
            sw.Stop();
            Console.WriteLine($"Parallel foreach: {sw.ElapsedMilliseconds}ms");

            void Fill(int x)
            {
                arr1[x] = x;
                arr2[x] = x;
                arr3[x] = x;
            }
        }

        static void Task6()
        {
            int count = 0;
            int maxCount = 100;

            // Want some magic? Uncomment Thread.Sleep(200);
            Parallel.Invoke(() =>
            {
                while (count < maxCount)
                {
                    //Thread.Sleep(200);
                    count++;
                    Console.WriteLine($"#1: {count}");
                }
            },
            () =>
            {
                while (count < maxCount)
                {
                    //Thread.Sleep(200);
                    count++;
                    Console.WriteLine($"#2: {count}");
                }
            },
            () =>
            {
                while (count < maxCount)
                {

                    //Thread.Sleep(200); ;
                    count++;
                    Console.WriteLine($"#3: {count}");
                }
            });



        }

        static void Task7()
        {
            BlockingCollection<string> bc = new BlockingCollection<string>(15);

            Task[] goods = new Task[10]
            {
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Table"); } }),
                new Task(() => { while (true) { Thread.Sleep(600); bc.Add("Closet"); } }),
                new Task(() => { while (true) { Thread.Sleep(550); bc.Add("Mirror"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); bc.Add("Kettle"); } }),
                new Task(() => { while (true) { Thread.Sleep(500); bc.Add("Windowsill"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Microwave"); } }),
                new Task(() => { while (true) { Thread.Sleep(600); bc.Add("Bed"); } }),
                new Task(() => { while (true) { Thread.Sleep(550); bc.Add("Door"); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); bc.Add("Flowerpot"); } }),
                new Task(() => { while (true) { Thread.Sleep(500); bc.Add("Chair"); } })
            };

            Task[] customers = new Task[10]
            {
                new Task(() => { while (true) { Thread.Sleep(300); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(400); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(2300); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(1700); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(1500); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(2000); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(1000); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(250); bc.Take(); } })
            };

            foreach (var i in goods)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            foreach (var i in customers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            int count = 1;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(300);
                    Console.Clear();
                    Console.WriteLine("_______Storehouse_______");

                    foreach (var i in bc)
                    {
                        Console.WriteLine(i);
                    }
                    if (bc.Count == 0)
                    {
                        Console.WriteLine("EMPTY!!!");
                    }
                    Console.WriteLine("________________________");
                }
            }
        }

        static void Task8()
        {
            void Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 7; i++)
                    result *= i;
                Thread.Sleep(1000);
                Console.WriteLine($"7! = {result}");
            }

            async void FactorialAsync()
            {
                Console.WriteLine("FA start");
                await Task.Run(() => Factorial());
                Console.WriteLine("FA ends");
            }

            FactorialAsync();
            Console.ReadKey();
        }
    }
}
