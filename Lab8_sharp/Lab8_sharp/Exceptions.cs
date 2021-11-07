using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_sharp
{
    class TooManyElementsException : Exception
    {
        public TooManyElementsException(string message) : base(message) => Console.WriteLine(message);
    }
}
