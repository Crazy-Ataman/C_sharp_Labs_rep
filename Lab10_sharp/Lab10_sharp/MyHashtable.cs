using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab10_sharp
{
    public class MyHashtable : IEnumerable<Worker>
    {
        // Chaining method or open hashing is used 
        public class Item
        {   // To store the elements of a hash table 
            public string Key { get; private set; }

            public string Value { get; private set; }

            public Item(Worker itemWorker)
            {
                if (string.IsNullOrEmpty(itemWorker.Name))
                {
                    throw new ArgumentNullException(nameof(itemWorker.Name));
                }

                if (string.IsNullOrEmpty(itemWorker.Specialized))
                {
                    throw new ArgumentNullException(nameof(itemWorker.Specialized));
                }

                Key = itemWorker.Name;
                Value = itemWorker.Specialized;
            }

            public Item(string key, string value)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Key = key;
                Value = value;
            }

            public override string ToString() => Key;
        }
        // The maximum length of the key field. 
        private readonly byte _maxSize = 255;
        // The collection of stored data. 
        private Dictionary<int, List<Item>> _items = null;
        // A collection of stored data in a hash table as Hash-Value pairs. 
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => _items.ToList().AsReadOnly();


        public MyHashtable()
        {
            // Initialize the collection with the maximum number of elements. 
            _items = new Dictionary<int, List<Item>>(_maxSize);
        }

        public void Add(string key, string value)
        {
            // Check the input data for correctness. 
            IsNullOrEmpty(key);

            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"The maximum key length is {_maxSize} characters.", nameof(key));
            }

            IsNullOrEmpty(value);

            var item = new Item(key, value);

            var hash = GetHash(item.Key);

            List<Item> hashTableItem = null;
            if (_items.ContainsKey(hash))
            {
                hashTableItem = _items[hash];

                var oldElementWithKey = hashTableItem.SingleOrDefault(x => x.Key == item.Key);
                if (oldElementWithKey != null)
                {
                    throw new ArgumentException($"The hash table already contains an item with a key {key}. The key must be unique.", nameof(key));
                }

                _items[hash].Add(item);
            }
            else
            {
                hashTableItem = new List<Item> { item };
                _items.Add(hash, hashTableItem);
            }
        }

        public void Add(Worker itemWorker)
        {
            var item = new Item(itemWorker);

            var hash = GetHash(item.Key);

            List<Item> hashTableItem = null;
            if (_items.ContainsKey(hash))
            {
                hashTableItem = _items[hash];

                var oldElementWithKey = hashTableItem.SingleOrDefault(x => x.Key == item.Key);
                if (oldElementWithKey != null)
                {
                    throw new ArgumentException($"The hash table already contains an item with a key {itemWorker.Name}. The key must be unique.", nameof(itemWorker.Name));
                }

                _items[hash].Add(item);
            }
            else
            {
                hashTableItem = new List<Item> { item };
                _items.Add(hash, hashTableItem);
            }
        }

        public void Delete(string key)
        {
            IsNullOrEmpty(key);

            var hash = GetHash(key);

            // No such hash 
            if (!_items.ContainsKey(hash))
            {
                return;
            }

            var hashTableItem = _items[hash];

            var item = hashTableItem.SingleOrDefault(x => x.Key == key);

            if (item != null)
            {
                hashTableItem.Remove(item);
            }
        }

        public string Search(string key)
        {
            var hash = GetHash(key);

            if (!_items.ContainsKey(hash))
            {
                return null;
            }

            var hashTableItem = _items[hash];

            if (hashTableItem != null)
            {
                // SingleOrDefault returns the single element found in the input sequence. 
                var item = hashTableItem.SingleOrDefault(x => x.Key == key);

                if (item != null)
                {
                    return item.Value;
                }
            }

            // Return null, if found nothing.
            return null;
        }

        private int GetHash(string value)
        {
            IsNullOrEmpty(value);

            if (value.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(value));
            }

            var hash = value.Length;
            return hash;
        }

        public void ShowMyHashTable()
        {
            Console.WriteLine("My Hashtable:");
            foreach (var item in Items)
            {
                Console.WriteLine("_______________________________________________________");
                // Displaying the hash 
                Console.WriteLine(item.Key);

                // Display all the values stored under this hash. 
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"\tKey: {value.Key}, Value: {value.Value}");
                }
            }
            Console.WriteLine();
        }

        public void IsNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public IEnumerator<Worker> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
