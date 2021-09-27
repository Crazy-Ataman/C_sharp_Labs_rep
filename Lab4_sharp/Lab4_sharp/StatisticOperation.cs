using System.Linq;

namespace Lab4_sharp
{
    public static class StatisticOperation
    {
        // Count all items in the set.
        public static int Count_items_of_set(Set<string> set) => set.Count();
        // Return the difference between maximum and minimum lengths.
        public static int Difference_max_and_min(Set<string> set) 
            => set.ToList().Max(x => x.Length) - set.ToList().Min(x => x.Length);
        // Concat all strings in the one string.
        public static string Concat_all_strings(Set<string> set)
            => string.Join(null, set); // Join(separator, string[] array)
    }
}