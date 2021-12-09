using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Lab15_sharp
{
    internal static class OddAndEven
    {


        internal static void SingleThread(int n)
        {
            FileInfo file = new FileInfo(@"..\..\..\First_even,then_odd.txt");
            if (file.Exists)
            {
                file.Delete();
            }
            object locker = new object();
            bool acquiredLock = false;
            Thread OddThread = new Thread(new ThreadStart(PrintOdd));
            Thread EvenThread = new Thread(new ThreadStart(PrintEven));
            EvenThread.Start();
            OddThread.Start();

            void PrintOdd()
            {
                Monitor.Enter(locker, ref acquiredLock);
                var odds = new List<int>();
                Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
                for (int i = 1; i <= n; i += 2)
                {
                    Thread.Sleep(20);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.Write(i + " ");
                    Console.Write($"{i} ");
                    odds.Add(i);
                }
                using var writer = new StreamWriter(@"..\..\..\First_even,then_odd.txt", true);
                writer.Write(string.Join(" ", odds));
                writer.Close();
                Monitor.Exit(locker);
            }

            void PrintEven()
            {
                lock (locker)
                {
                    var evens = new List<int>();
                    for (int i = 0; i <= n; i += 2)
                    {
                        Thread.Sleep(150);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{i} ");
                        evens.Add(i);
                    }
                    using var writer = new StreamWriter(@"..\..\..\First_even,then_odd.txt", true);
                    writer.Write(string.Join(" ", evens));
                    writer.Write(" ");
                    writer.Close();
                }
            }
        }

        public static void Together(int n)
        {
            using var writer = new StreamWriter(@"..\..\..\Odd,even,odd,even.txt");
            Mutex mutex = new Mutex();
            Thread OddThread = new Thread(new ThreadStart(PrintOdd));
            Thread EvenThread = new Thread(new ThreadStart(PrintEven));
            EvenThread.Start();
            OddThread.Start();
            EvenThread.Join();
            OddThread.Join();

            void PrintOdd()
            {
                for (int i = 1; i <= n; i += 2)
                {
                    // mutexObj.WaitOne() suspends thread execution until the mutexObj mutex is acquired.
                    mutex.WaitOne();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{i} ");
                    writer.Write($"{i} ");
                    // The thread releases it using the mutexObj.ReleaseMutex () method.
                    mutex.ReleaseMutex();
                }
            }

            void PrintEven()
            {
                for (int i = 0; i <= n; i += 2)
                {
                    Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                    mutex.WaitOne();
                    Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{i} ");
                    writer.Write($"{i} ");
                    mutex.ReleaseMutex();
                }
            }
        }


    }
}
