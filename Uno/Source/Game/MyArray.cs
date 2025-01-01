using System.Collections;
using System.Collections.Generic;

namespace Uno
{
    public class MyArray<T> : IEnumerable<T>
    {
        private T[] _array;

        public MyArray(int length)
        {
            _array = new T[length];
        }

        public T this[int index]
        {
            get { 
                return _array[index]; 
            }
            set { _array[index] = value; }
        }

        public int Length => _array.Length;

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
