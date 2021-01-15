using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Item : IComparable<Item>
    {
        public String Name { get; set; }
        public int GoldPieces { get; set; }
        public double Weight { get; set; }

        public Item(string name, int goldPieces, double weight)
        {
            this.Name = name;
            this.GoldPieces = goldPieces;
            this.Weight = weight;
        }

        /// <summary>
        /// Must be comparable with other Items based on the item name
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Item other)
        {
            return this.Name.CompareTo(other.Name);
        }


        /// <summary>
        /// The object Equals() method must also be overridden using all of the qualities of a proper equals 
        /// discussed in the slides (equals() in java); 
        /// where Items with ALL the same properties will return as equal (Name/Gold/Weight)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   this.Name == item.Name &&
                   this.GoldPieces == item.GoldPieces &&
                   this.Weight == item.Weight;
        }
        /// <summary>
        /// Should print out a sentence: ItemName is worth 999gp and weighs 999kg
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Name} is worth {this.GoldPieces}gp and weighs {this.Weight}kg";
        }
    }
}
