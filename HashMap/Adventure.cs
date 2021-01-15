using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Adventure
    {
        private HashMap<StringKey, Item> map;

        public HashMap<StringKey, Item> GetMap()
        {
            return map;
        }

        public Adventure(String itemList)
        {
            if (itemList == null) throw new ArgumentNullException();

            try
            {
                string[] filelines = File.ReadAllLines(itemList);

                map = new HashMap<StringKey, Item>();

                String[] item;


                for(int i = 0; i< filelines.Length; i++)
                {
                    item = filelines[i].Split(',');
                    map.Put(new StringKey(item[0]), new Item(item[0], int.Parse(item[1].Trim()), double.Parse(item[2].Trim())));
                }
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        public string PrintLootMap()
        {

            List<Item> list = new List<Item>();

            IEnumerator<Item> v = map.Values();

            while (v.MoveNext())
            {
                list.Add(v.Current);
               // Console.WriteLine("{0}", v.Current);
            }
            
            Console.WriteLine("Sorting +++++++++++++");
            list.Sort();
            string result = "";
            foreach (var item in list)
            {
                if(item.GoldPieces > 0) {
                
                    result += item + "\n";
                    Console.WriteLine("{0}", item);
                }
            }


            return result;
        }
    }
}
