using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Run_Minus.Core.Test_Runner
{
    internal class TestTypeCache : ICache<string>
    {
        private readonly HashSet<string> cache;
        private readonly bool isReadonly;
        public int Count => cache.Count;

        public bool IsReadOnly => true;

        public TestTypeCache(int capacity = 3)
        {
            cache = new HashSet<string>(capacity);
        }

        public TestTypeCache(string[] types)
        {
            cache = new HashSet<string>(types);
        }

        public void Add(string item) => cache.Add(item);

        public void Clear() => cache.Clear();

        public int CompareTo(string? other)
        {
            if (other == null)
                return 1;
            return CompareTo(other);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) 
                return 1;
            return obj is TestTypeCache casted ? this.CompareTo(casted) : throw new ArgumentException($"Object is not a {nameof(TestTypeCache)}");
        }

        public bool Contains(string item) => cache.Contains(item);

        public void CopyTo(string[] array, int arrayIndex) => cache.CopyTo(array, arrayIndex);

        public IEnumerator<string> GetEnumerator()
        {
            return cache.GetEnumerator();
        }

        public bool Remove(string item) => cache.Remove(item);
        public bool RemoveAllInstances(string item)
        {
            if(!cache.Contains(item))
                return false;
            while (cache.Contains(item))
            {
                cache.Remove(item);
            }
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
