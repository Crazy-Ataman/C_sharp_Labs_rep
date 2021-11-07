using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab8_sharp
{
    // T - generic type parameter.
    // <typeparam name="T"> The type of data stored in the set. 
    public class Set <T> : IEnumerable<T> , IGeneric<T> where T : class
    {   // IEnumerable - requiere to realize functions public IEnumerator<T> GetEnumerator() and IEnumerator IEnumerable.GetEnumerator()
        // IEnumerable - also require System.Collections and System.Collections.Generic.

        // Constructor
        public List<T> items = new();
        public int Count => items.Count;

        public void Add(T item)
        {   // Add data to set.. 
            // A set can only contain unique elements, 
            // therefore, if the set already contains such a data element, then we do not add it. 
            if (!items.Contains(item))
            {
                if (items.Count < 4) 
                {
                    items.Add(item);
                }
                else
                {
                    throw new TooManyElementsException("The set can contain up to 4 elements.");
                }
            }
        }
        public void Remove(T item) => items?.Remove(item);

        // Return an enumerator that iterates over all the elements of the set. 
        // Use the enumerator of the list of data items of the set. 
        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        // The IEnumerator object used to traverse the collection. 
        // Use the enumerator of the list of data items of the set. 
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        public void Find(T item_T)
        {
            if (items.Contains(item_T))
            {
                Console.WriteLine($"The element {item_T} found.");
            }
            else
            {
                Console.WriteLine($"The element {item_T} not found.");
            }
        }

        public void Show()
        {
            foreach (var item in items)
                Console.WriteLine(item);
        }
    }
}