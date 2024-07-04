using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Run_Minus.Core.Execution
{
    internal class Cache<T> : ICache<T>
    {
        private readonly HashSet<T> typeCache;
        private readonly bool isReadonly;
        public int Count => typeCache.Count;

        public bool IsReadOnly => true;

        public Cache(int capacity = 3)
        {
            typeCache = new HashSet<T>(capacity);
        }

        public Cache(IEnumerable<T> types)
        {
            typeCache = new HashSet<T>(types);
        }

        public void Add(T item) => typeCache.Add(item);

        public void Clear() => typeCache.Clear();

        public int CompareTo(T? other)
        {
            if (other == null)
                return 1;
            return CompareTo(other);
        }
        // Todo: this compareTo logic is completely broken, also remove the throw and just return -1
        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;
            return obj is not Cache<T> casted ? throw new ArgumentException($"Object is not a {nameof(Cache<T>)}") : CompareTo(casted);
        }

        public bool Contains(T item) => typeCache.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => typeCache.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator()
        {
            return typeCache.GetEnumerator();
        }

        public bool Remove(T item) => typeCache.Remove(item);
        public bool RemoveAllInstances(T item)
        {
            if(!typeCache.Contains(item))
                return false;
            while (typeCache.Contains(item))
            {
                typeCache.Remove(item);
            }
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
