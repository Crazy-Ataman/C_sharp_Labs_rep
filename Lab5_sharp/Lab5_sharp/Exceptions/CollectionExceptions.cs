using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_6_7_sharp.Exceptions
{
    class CollectionExceptions : Exception
    {
        public CollectionExceptions(string message) : base(message) { }
    }
}
