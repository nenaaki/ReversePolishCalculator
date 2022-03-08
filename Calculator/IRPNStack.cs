using System.Collections;

namespace Calculator
{
    internal interface IRPNStack<T> : ICollection, IEnumerable<T>
    {
        void Push(T item);

        T Pop();
    }
}