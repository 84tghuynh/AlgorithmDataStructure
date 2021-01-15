using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Entry<K,V>
    {
        public K Key { set; get; }
        public V Value { set; get; }

        public Entry(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }
}
