using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Point : IEquatable<Point> //: IComparable<Point>
    {
        /// <summary>
        /// Set/Get Row number
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Set/Get Column number
        /// </summary>
        public int Column { get; set; }

        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Print [row,column]
        /// Ex: [2,3]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{Row}, {Column}]";
        }

        /// <summary>
        /// Compare row
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Point other)
        {
            return this.Row.CompareTo(other.Row);
        }

        public bool Equals(Point other)
        {
            return this.Row.Equals(other.Row) && this.Column.Equals(other.Column);
        }
    }
}
