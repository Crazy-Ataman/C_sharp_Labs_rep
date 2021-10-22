using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_6_7_sharp.Exceptions
{
    class ControllerExceptions : Exception
    {
        public ControllerExceptions(string message) : base(message) { }
}
}
