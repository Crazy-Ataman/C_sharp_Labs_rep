using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_sharp
{ 
    public class Owner
    {
        public readonly int id;
        public string name;
        public string organization;
        // Constructor
        public Owner(string name, string organization)
        {
            this.name = name;
            this.organization = organization;
            id = GetHashCode();
        }
    }
    // T - generic type parameter.
    // <typeparam name="T"> The type of data stored in the set.
    public class Set <T> : IEnumerable<T>
    {   // IEnumerable - requiere to realize functions public IEnumerator<T> GetEnumerator() and IEnumerator IEnumerable.GetEnumerator()
        // IEnumerable - also require System.Collections and System.Collections.Generic.
        public class Date
        {
            private readonly DateTime time;
            // Constructor
            public Date()
            {
                time = DateTime.Now;
            }
            // Method
            public void ShowDate() => Console.WriteLine(time);
        }
        // Initialize object Owner.
        public Owner master = new ("Max", "BSTU");
        // Constructor
        public List<T> items = new();
        public int Count => items.Count;
        public void ShowSet()
        {   // Show set items.
            foreach(var item in items)
                Console.WriteLine(item);
        }
        public void Add(T item)
        {   // Add data to set.. 
            // A set can only contain unique elements, 
            // therefore, if the set already contains such a data element, then we do not add it. 
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }
        public void Remove(T item) => items?.Remove(item);
        public static Set<T> Union(Set<T> set1, Set<T> set2)
        {   // Union of sets. 
            var result_set = new Set<T>();
            var items_of_result_set = new List<T>();
            if (set1.items.Count > 0)
            {   // If the first input set contains data items => add them to the result set. 
                // The list is a reference type => it is necessary not only to transfer data, but to create their duplicates. 
                items_of_result_set.AddRange(new List<T>(set1.items));
            }
            if (set2.items.Count > 0)
            {   // If the second input set contains data items => add them to the result set. 
                // The list is a reference type => it is necessary not only to transfer data, but to create their duplicates. 
                items_of_result_set.AddRange(new List<T>(set2.items));
            }
            // Remove all duplicates from the resulting set of data items. 
            // Distinct - removes duplicate elements from the input sequence.
            result_set.items = items_of_result_set.Distinct().ToList();
            return result_set;
        }
        public static Set<T> Intersection(Set<T> set1, Set<T> set2)
        {   // Intersection of sets.
            var result_set = new Set<T>();
            if (set1.Count < set2.Count)
            {
                foreach(var item in set1.items)
                {   // If an element from the first set is contained in the second set => add it to the result set.
                    if (set2.items.Contains(item))
                    {
                        result_set.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2.items)
                {   // If an element from the second set is contained in the first set => add it to the result set.
                    if (set1.items.Contains(item))
                    {
                        result_set.Add(item);
                    }
                }
            }
            return result_set;
        }
        public static Set<T> Difference(Set<T> set1, Set<T> set2)
        {   // Difference of sets.
            var result_set = new Set<T>();
            if (set1.Count < set2.Count)
            {
                foreach (var item in set1.items)
                {   // If an element from the first set isn'T contained in the second set => add it to the result set.
                    if (!set2.items.Contains(item))
                    {
                        result_set.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2.items)
                {   // If an element from the second set isn't contained in the first set => add it to the result set.
                    if (!set1.items.Contains(item))
                    {
                        result_set.Add(item);
                    }
                }
            }
            return result_set;
        }
        // Subset.
        // Loop through the elements of the first set.
        // If all the elements of the first set are contained in the second => this is a subset.
        // Return true, otherwise false.
        public static bool Subset(Set<T> set1, Set<T> set2)
            => set1.items.All(s => set2.items.Contains(s));
        public void DotAtTheEnd(Set<string> set)
        {   // Adding dot at the end of string.
            for (int i = 0; i < set.Count; i++)
                set.items[i] += ".";
        }
        public void DeletingNull(Set<string> set) => set?.Remove(null);
        public void DeletingNull(Set<int> set) => set?.Remove(0);

        // Return an enumerator that iterates over all the elements of the set. 
        // Use the enumerator of the list of data items of the set. 
        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        // The IEnumerator object used to traverse the collection. 
        // Use the enumerator of the list of data items of the set. 
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
        // Overload of operators.
        public static Set<T> operator -(Set<T> set1, T item)
        {
            set1?.Remove(item);
            return set1;
        }
        public static Set<T> operator *(Set<T> set1, Set<T> set2) 
            => Intersection(set1, set2);
        // Subset (inverse).
        // If all the elements of the second set are contained in the first => this is a subset.
        // Return true, otherwise false.
        public static bool operator <(Set<T> set1, Set<T> set2)
            => set2.items.All(s => set1.items.Contains(s));
        public static bool operator >(Set<T> set1, Set<T> set2) 
            => Subset(set1, set2);
        public static Set<T> operator &(Set<T> set1, Set<T> set2) 
            => Difference(set1, set2);
    }
}