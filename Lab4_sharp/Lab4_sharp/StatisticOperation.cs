using System;

namespace Lab4_sharp
{
    public static class StatisticOperation
    {
        public static int Count_items_of_set(Set<string> set)
        {   // Count all items in the set.
            int counter = 0;
            foreach (var item in set.items)
                counter++;
            return counter;
        }
        public static int Max_length_string_in_set(Set<string> set)
        {   // Return the maximum string length.
            string max_string = "";
            foreach (var item in set.items)
                if (max_string.Length < item.Length)
                    max_string = item;
            return max_string.Length;
        }
        public static int Min_length_string_in_set(Set<string> set)
        {   // Return the minimum string length.
            string min_string = set.items[0];
            foreach (var item in set.items)
                if (min_string.Length > item.Length)
                    min_string = item;
            return min_string.Length;
        }
        public static int Difference_max_and_min(Set<string> set)
        {   // Return the difference between maximum and minimum lengths.
            return Max_length_string_in_set(set) - Min_length_string_in_set(set);
        }
        public static string Concat_all_strings(Set<string> set)
        {   // Concat all strings in the one string.
            string result_string = "";
            foreach (var item in set.items)
                result_string += item;
            return result_string;
        }   
    }
}