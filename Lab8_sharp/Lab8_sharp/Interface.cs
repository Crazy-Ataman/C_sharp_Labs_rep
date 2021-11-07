using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_sharp
{
    interface IGeneric<T>
    {
        void Add(T item);
        void Remove(T item);
        void Find(T item);
        void Show();
    }
}
