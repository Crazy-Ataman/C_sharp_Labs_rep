using System;
using System.Text.RegularExpressions;

namespace Lab9_sharp
{
    public class StringEditor
    {
        public static readonly Func<string, string> ToLower = str => str.ToLower();

        public static readonly Func<string, string> ToUpper = str => str.ToUpper();

        public static readonly Func<string, string> RemoveSpaces = str
            => str.Replace(" ", string.Empty);

        public static readonly Func<string, string> RemovePunctuation = str
            => Regex.Replace(str, "[.,:;!?]", string.Empty);

        public static readonly Func<string, string> AddSymbol = str => str += "?!";
    }
}
