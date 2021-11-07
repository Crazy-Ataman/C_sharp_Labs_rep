using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_sharp
{
    internal abstract class Plants
    {

    }

    internal class Bush : Plants
    {
        public override string ToString() => "Bush";
    }

    internal class Flower : Plants
    {
        public override string ToString() => "Flower";
    }

}
