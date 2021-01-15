using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class HashMap<K,V>
    {
        public const double DEFAULT_LOADFACTOR = 0.75;
        public const int CAPACITY = 11;
        public double LoadFactor { get; set; }
        public int Capacity { get; set; }

        private int RealSize;
        private int PlaceHolder;
        

        public Entry<K,V>[] Table { get; set; }

        /// <summary>
        /// Constructor, initializes Table to default size and load factor to default size
        /// </summary>
        public HashMap() : this(CAPACITY)
        {
            //LoadFactor = DEFAULT_LOADFACTOR;
            //Capacity = CAPACITY;
            //Table = new Entry<K, V>[Capacity];

            //RealSize = 0;
            //PlaceHolder = 0;
        }

        /// <summary>
        /// Constructor, initializes Table to size passed and assigns load factor to default value.
        /// </summary>
        /// <param name="capacity"></param>
        public HashMap(int capacity) : this(capacity,DEFAULT_LOADFACTOR)
        {
            //if (capacity <= 0) throw new ArgumentException();
            //Capacity = capacity;
            //LoadFactor = DEFAULT_LOADFACTOR;
            //Table = new Entry<K, V>[Capacity];

            //RealSize = 0;
            //PlaceHolder = 0;
        }

        /// <summary>
        /// Constructor, initializes Table to size passed and assigns load factor to value passed.
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="loadFactor"></param>

        public HashMap( int capacity, double loadFactor)
        {
            
            if (capacity <= 0 || loadFactor <= 0 || loadFactor>= 1 ) throw new ArgumentException();
            LoadFactor = loadFactor;
            Capacity = capacity;

            Table = new Entry<K, V>[Capacity];

            RealSize = 0;
            PlaceHolder = 0;
        }

        /// <summary>
        /// Looks for the next available bucket based on the key passed, (Uses linear probing for collision handling, will return to the 0 index and continue searching if array length is reached). Note, if the key exists, it returns the bucket of the matching key. 
        /// DO NOT LOOP THROUGH EVERY ENTRY FROM 0 TO ARRAY LENGTH IN THIS METHOD.Start from the starting bucket and use linear probing. It may end up going through many indexes, but in practice it will never do that because you have a threshold and there are many empty array spots.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetMatchingOrNextAvailableBucket(K key)
        {
            int bucket = key.GetHashCode() % Table.Length;

            if (Table[bucket] == null)
            {
                return bucket;
            }

            if (Table[bucket] != null && Table[bucket].Key != null && Table[bucket].Key.Equals(key))
            {
                return bucket;
            }

            // Find from the next position of bucket
            if (bucket == Table.Length - 1) bucket = 0;
            else bucket++;
            
            return LinearProbing(key, bucket);
        }

        private int LinearProbing(K key, int bucket)
        {
            // First round search start from bucket
            // flag = true && bucket = 0 if first round search not found an empty/availble spot
            bool flag = false;
            int index = bucket;

            while (index < Table.Length && !flag)
            {
                if (Table[index] == null) return index;

                if (Table[index].Key.Equals(key))  return index;
                
                if( index == Table.Length - 1)
                {
                    flag = true;
                    index = 0;
                }else 
                    index++;
            }

            // Second round 
            // BUCKET - 1: because BUCKET is first position + 1 found by First hashcode: hashcode % Table.Length
            while (bucket > 0 && index < bucket-1 && flag)
            {
                if (Table[index] == null) return index;

                if (Table[index].Key.Equals(key)) return index;
                
                index++;
            }

            return index;
        }

        /// <summary>
        /// Adds or Updates the bucket found by hashing the key.  
        /// If the bucket is empty insert a new entry with the passed key and value pair and return null.  
        /// If the bucket is not empty, override the old value in the bucket and return the old value. 
        /// Note that this must handle collisions through linear probing. (use GetMatchingOrNextAvailableBucket()). When adding a new entry you must check if you require a rehash first. If the size + placeholders plus the new entry is equal to the threshold, then run rehash (see slides for more details).
        /// DO NOT LOOP THROUGH EVERY ENTRY FROM 0 TO ARRAY LENGTH IN THIS METHOD.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public V Put(K key, V value)
        {
            if (key == null || value == null) throw new ArgumentNullException();
            
            V v = default(V);

            int threshold = (int)(Capacity * LoadFactor);

           

            int bucket = GetMatchingOrNextAvailableBucket(key);

            // Add
            if (Table[bucket] == null)
            {
                // Rehash before put in
                if (RealSize + PlaceHolder + 1 >= threshold)
                {
                    ReHash();
                    // DisplayTable();
                    bucket = GetMatchingOrNextAvailableBucket(key);
                }

                
                Table[bucket] = new Entry<K, V>(key, value);
                RealSize++;

                //DisplayTable();

                return v;
            }

            // Update
            if (Table[bucket] != null && Table[bucket].Key != null && Table[bucket].Key.Equals(key))
            {
                v = Table[bucket].Value;
                Table[bucket].Value = value;

                if (v == null)
                {
                    PlaceHolder--;
                    RealSize++;
                }

                //DisplayTable();
                return v;
            }
            
            return v;
        }

        /// <summary>
        /// Returns the value located at the bucket found by hashing the key. 
        /// This may return null if no matching key exists at this bucket. 
        /// Note that this must handle collisions through linear probing. (use GetMatchingOrNextAvailableBucket()). 
        /// DO NOT LOOP THROUGH EVERY ENTRY FROM 0 TO ARRAY LENGTH IN THIS METHOD.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            int bucket = GetMatchingOrNextAvailableBucket(key);

            if (Table[bucket] == null || !Table[bucket].Key.Equals(key)) return default(V);

            return Table[bucket].Value;
        }

        /// <summary>
        /// Looks up the bucket based on the hashcode of the key. 
        /// If a value exists at this bucket, set the value to null and increase your placeholder counter by one. 
        /// If nothing exists at this bucket return null. 
        /// Note that this must handle collisions through linear probing. (use GetMatchingOrNextAvailableBucket()).
        /// DO NOT LOOP THROUGH EVERY ENTRY FROM 0 TO ARRAY LENGTH IN THIS METHOD.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Remove(K key)
        {
            if (key == null) throw new ArgumentNullException();

            int bucket = GetMatchingOrNextAvailableBucket(key);

            if (Table[bucket] != null && Table[bucket].Key.Equals(key) && Table[bucket].Value != null)
            {
                V v = Table[bucket].Value;

                Table[bucket].Value = default(V);
                PlaceHolder++;
                RealSize--;

                return v;

            }

            return default(V);

        }

        /// <summary>
        /// Returns an IEnumerator compatible object containing only the keys of each Entry in the Table (skip placeholders).
        /// </summary>
        /// <returns></returns>

        public IEnumerator<K> Keys()
        {
            List<K> list = new List<K>();
            int i = 0;
            while(i < Table.Length)
            {
                if (Table[i] != null && Table[i].Key != null && Table[i].Value != null) 
                    
                    list.Add(Table[i].Key);

                i++;
            }

            return list.GetEnumerator();

        }

        /// <summary>
        /// Returns an IEnumerator compatible object containing only the values of each Entry in the Table (skip placeholders).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<V> Values()
        {
            List<V> list = new List<V>();
            int i = 0;
            while (i < Table.Length)
            {
                if (Table[i] != null && Table[i].Key != null && Table[i].Value != null)

                    list.Add(Table[i].Value);

                i++;
            }

            return list.GetEnumerator();
        }
        private void DisplayTable()
        {
            int i = 0;
            while (i < Table.Length)
            {
                if (Table[i] != null && Table[i].Value != null)
                {
                    Console.WriteLine("Index: {0}, Key: {1}, Value: {2}", i, Table[i].Key, Table[i].Value);
                }
                else
                {
                    Console.WriteLine("Index: {0}", i);
                }

                i++;
            }

            Console.WriteLine("RealSize: {0}, Length: {1}", RealSize, Table.Length);
        }

        /// <summary>
        /// Occurs when the threshold (table length * load factor) is reached when adding a new Entry<K,V> to the Table.  Note that placeholders (removed values) count towards this total.  Example:  An array is size 10, the load factor is 0.3 (30%), therefore the threshold is 10*0.3 = 3.  After using Put() twice, the size goes up to 2. When using Remove() once, the size goes down to 1, but the placeholder count is increased to 1.  Now when we use Put() again, the threshold is reached, because 1 size + 1 placeholder is 2 and adding another entry will bring us up to 3, the threshold value. 
        /// Perform a resize to find the new Table array length(see slides for details on resize and prime numbers). Migrate each entry from the old Table into the new table.IMPORTANT NOTE: When migrating old table buckets, you must recalculate the new table buckets based on the new table length! This is the most common mistake.
        /// </summary>
        private void ReHash()
        {
            Capacity = ReSize();
            PlaceHolder = 0;
            RealSize = 0;
            MigrateTable(Capacity);
            
            //Console.WriteLine("Put: Capacity: {0}, Length: {1}", Capacity, Table.Length);
        }

        public void MigrateTable(int newCapacity)
        {
            Entry<K, V>[] currentTable = Table;

            Table = new Entry<K, V>[newCapacity];
            int i = 0;
            int bucket;
            while (i < currentTable.Length)
            {
                if (currentTable[i] != null && currentTable[i].Value != null) 
                {
                    bucket = GetMatchingOrNextAvailableBucket(currentTable[i].Key);
                    Table[bucket] = new Entry<K, V>(currentTable[i].Key, currentTable[i].Value);
                    RealSize++;

                   // Console.WriteLine("Key: {0}, Value: {1}", currentTable[i].Key, currentTable[i].Value);
                }
                   
                i++;
            }
        }
        public bool Prime(double num)
        {
            if (num % 2 == 0) return false;

            double square_root = Math.Sqrt(num);
            int i = 3;
            while ( i < square_root)
            {
                if (num % i == 0) return false;
                i++;
            }

            return true;
        }

        /// <summary>
        /// During a Rehash, a new array size must be calculated. We start by doubling the original size, adding 1 and finding the next prime number, see theory slides for this algorithm.
        /// </summary>
        /// <returns></returns>

        public int ReSize()
        {
            int newLength = 2 * Capacity + 1;

            while (!Prime(newLength)) newLength++;
            

            return newLength;
        }

        /// <summary>
        /// Returns current size (note, this DOES NOT include placeholders) May be a smart property in C#.
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return RealSize;
        }

        /// <summary>
        /// Returns true if number of active entries in the array is 0.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => RealSize == 0;

        /// <summary>
        /// Wipes out the array and all placeholders
        /// </summary>
        public void Clear()
        {
            //int i = 0;
            //while (i< Table.Length)
            //{
            //    if (Table[i] != null)
            //    {
            //        Table[i].Key = default(K);
            //        Table[i].Value = default(V);
            //    }
            //    i++;
            //}
            Table = new Entry<K, V>[Table.Length];
            RealSize = 0;
            PlaceHolder = 0;
          
        }
    }
}
