using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            string itemList = AppDomain.CurrentDomain.BaseDirectory + "ItemData.txt";

            string expectedResult = "Armor is worth 250gp and weighs 35kg\nArrow is worth 2gp and weighs 0.1kg\nAxe is worth 250gp and weighs 3.5kg\nBackpack is worth 20gp and weighs 0.4kg\nBelt is worth 60gp and weighs 0.09kg\nBow is worth 100gp and weighs 1.5kg\nChest is worth 50gp and weighs 15kg\nCrossbow is worth 350gp and weighs 9kg\nDagger is worth 95gp and weighs 0.6kg\nDiamond is worth 5000gp and weighs 0.01kg\nHelmet is worth 35gp and weighs 1.1kg\nLantern is worth 45gp and weighs 2kg\nPurse is worth 5gp and weighs 0.2kg\nQuiver is worth 60gp and weighs 0.3kg\nRing is worth 395gp and weighs 0.05kg\nScroll is worth 10gp and weighs 0.02kg\nStaff is worth 45gp and weighs 1kg\nSword is worth 300gp and weighs 2kg\nTorch is worth 15gp and weighs 1kg\n";

            Console.WriteLine("{0}", expectedResult);
            Adventure adventure = new Adventure(itemList);

            adventure.PrintLootMap();

            //double loadFactor = 0.5; // default
            //int capacity = 7; // default;

            //HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(capacity, loadFactor);
            //int threshold = (int)(capacity * loadFactor);
            //int i = 0;
            //for (i = 0; i < threshold - 1; i++)
            //{
            //    hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));


            //}

            //Console.WriteLine("Thresold: {0}", threshold);


            // just before the threshold, the table should still be the same
            //Assert.AreEqual(capacity, hashMap.Table.Length);
            //Assert.AreEqual(threshold - 1, hashMap.Size());

            //hashMap.Put(new StringKey("item" + i), new Item("item" + i, i, 0.0 + i));

            //Console.WriteLine("RealSize: {0}, Length: {1}", hashMap.Size(), hashMap.Table.Length);



            // the next prime after 7 is 7*2 = 14... and 14+1 is 15.. that's not prime, so 15+2 is 17!
            //Assert.AreEqual(17, hashMap.Table.Length);
            //Assert.AreEqual(threshold, hashMap.Size());



            //HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            //StringKey key = new StringKey("New Item");
            //Item item = new Item("New Item", 1, 1.0);
            //hashMap.Put(key, item);

            //int index = RetrieveKeyIndex(key, hashMap.Table);

            //Console.WriteLine("Key: {0}, bucket: {1}, index: {2}", key, key.GetHashCode() % 11, index);

            //Console.WriteLine("2 is prime: {0}", hashMap.Prime(2));
            //Console.WriteLine("3 is prime: {0}", hashMap.Prime(3));
            //Console.WriteLine("4 is prime: {0}", hashMap.Prime(4));
            //Console.WriteLine("5 is prime: {0}", hashMap.Prime(5));
            //Console.WriteLine("7 is prime: {0}", hashMap.Prime(7));
            //Console.WriteLine("17 is prime: {0}", hashMap.Prime(17));
            //Console.WriteLine("31 is prime: {0}", hashMap.Prime(31));
            //Console.WriteLine("93 is prime: {0}", hashMap.Prime(93));
            //Console.WriteLine("94 is prime: {0}", hashMap.Prime(94));
            //Console.WriteLine("95 is prime: {0}", hashMap.Prime(95));
            //Console.WriteLine("96 is prime: {0}", hashMap.Prime(96));
            //Console.WriteLine("97 is prime: {0}", hashMap.Prime(97));
            //Console.WriteLine("101 is prime: {0}", hashMap.Prime(101));
            //Console.WriteLine("collisionKey: {0}, bucket: {1}", collisionKey, collisionKey.GetHashCode() % 11);

            //Assert.AreEqual(index, hashMap.GetMatchingOrNextAvailableBucket(key));

            /////////////////////////////////////////////////////////////////////////////////////////////////////

            //GetMatchingOrNextAvailableBucket_Retuns_0_index_when_collision_on_last_bucket_occurs_Test
            //GetMatchingOrNextAvailableBucket_Retuns_0_when_entry_inserted_to_index_0_during_collision_on_last_index_Test()
            //HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>();
            //StringKey key = new StringKey("item");
            //StringKey collisionKey = new StringKey("item_COLLSION");
            //Item item = new Item("item", 1, 1.0);

            //hashMap.Put(key, item);

            //int index = RetrieveKeyIndex(key, hashMap.Table);

            ////Assert.AreEqual(hashMap.Table.Length - 1, index);

            //// we overwrite the spot that item originally hashes to...
            //hashMap.Table[index] = new Entry<StringKey, Item>(collisionKey, item);

            //// test to see if the next bucket is index 0 during a collision
            ////Assert.AreEqual(0, hashMap.GetMatchingOrNextAvailableBucket(key));

            //Console.WriteLine("Key: {0}, bucket: {1}, index: {2}", key, key.GetHashCode() % 11, index);
            //Console.WriteLine("collisionKey: {0}, bucket: {1}", collisionKey, collisionKey.GetHashCode() % 11);



            /////////////////////////////////////////////////////////////////////////

            //StringKey sK = new StringKey("stop");
            //StringKey sK1 = new StringKey("pots");
            //Console.WriteLine("Pow(31,0): {0}", sK.Pow(31, 0));
            //Console.WriteLine("Pow(31,1): {0}", sK.Pow(31, 1));
            //Console.WriteLine("Pow(31,2): {0}", sK.Pow(31, 2));
            //Console.WriteLine("Pow(31,3): {0}", sK.Pow(31, 3));

            //Console.WriteLine("Polynomial(31): {0}", sK.Polynomial(31));
            //Console.WriteLine("Polynomial(31): {0}", sK1.Polynomial(31));

            Console.ReadKey();

        }

        private static int RetrieveKeyIndex(StringKey key, Entry<StringKey, Item>[] table)
        {
            // PLEASE NOTE: this method is used for testing and may not be a valid way for students
            // to search their tables in the actual solution. Remember you need to handle collisions
            // and your look up should NOT be Big-O of N algorithm, unlike the below loop.
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null && table[i].Key.Equals(key))
                {
                    return i;
                }
            }
            return -1; // dummy value of -1 returned when no match found
        }
    }
}
