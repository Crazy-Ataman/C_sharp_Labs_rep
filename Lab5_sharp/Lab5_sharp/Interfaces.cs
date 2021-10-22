using System;

namespace Lab5_6_7_sharp
{
    internal interface IGrowing
    {
        void Grow();
        void Print();
    }

    public interface IGeneral<T>
    {
        void Add(T item);
        void Delete(int index);
        void Show();
    }
}
