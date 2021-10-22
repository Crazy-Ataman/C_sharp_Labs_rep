using Lab5_6_7_sharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Lab5_6_7_sharp
{
    partial class CollectionType<T> : IGeneral<T> where T : class
    {
        private int size;
        public List<T> list;

        public CollectionType() => list = new List<T>();
        public void Add(T item)
        {
            list.Add(item);
            size++;
        }

        public void Delete(int index)
        {
            if (index < 0)
                throw new CollectionExceptions("Index can't be negative.");
            // Assert need namespace System.Diagnostics
            // Analog exception.
            Debug.Assert(index < 9999999, "Index too large.");
            list.RemoveAt(index);
            size--;
        }

        public void Show()
        {
            foreach (T item in list)
                Console.WriteLine(item);
        }

        public int GetSize() => size;
    }
}