using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4 
{
    public class StringKey : IComparable<StringKey>
    {
        /// <summary>
        /// Getter/Setter
        /// will be using to make a hash value
        /// </summary>
        public String KeyName { get; set; }

        /// <summary>
        /// Constructor, initializes property KeyName
        /// </summary>
        /// <param name="keyName"></param>
        public StringKey(String keyName)
        {
            KeyName = keyName;
        }

        public int CompareTo(StringKey other)
        {
            return this.KeyName.CompareTo(other.KeyName);
        }

        //public override bool Equals(object obj)
        //{
        //    StringKey other = obj as StringKey;

        //    if (other != null)
        //    {
        //        return this.KeyName.Equals(other.KeyName);
        //    }
        //    else return false;
        //}

        public override bool Equals(object obj)
        {
            return obj is StringKey other &&
                  this.KeyName == other.KeyName;
                 
        }

        public override int GetHashCode()
        {
            return Polynomial(31);
        }

        /// <summary>
        /// X: coefficient
        /// Y: exponential
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Pow(int x, int n)
        {
            if (n == 0) return 1;
            else return x * Pow(x, n - 1);
        }
        /// <summary>
        /// a0* X0 + a1*X1 +a2 * X2 + a3 * X3 + … + a(n-1)*X(n-1)
        /// Where a is a letter from the string (in order)
        /// Example: “Stop”
        /// a0 = ‘S’
        /// a1 = ‘t’
        /// a2 = ‘o’, 
        /// a3 = ‘p;
        /// X: coEfficient
        /// </summary>
        /// <param name="coEfficient"></param>
        /// <returns></returns>

        public int Polynomial(int coEfficient)
        {
            int hascode = 0;

            for (int i = 0, x =1 ; i < KeyName.Length; x*=31, i++)
            {
                hascode += KeyName[i] * x;
            }
            return Math.Abs(hascode);

            //byte[] ascii = Encoding.ASCII.GetBytes(this.KeyName);
            //int i = 0;
            //foreach (Byte b in ascii)
            //{
            //    hascode += b * Pow(coEfficient, i);
            //    i++;
            //}

            //return Math.Abs(hascode);
        }

        /// <summary>
        /// Useful for debugging… could print out a sentence 
        /// such as: KeyName: namehere HashCode: hashcodehere
        /// Example: string expectedString = "KeyName: stop HashCode: 3446974";
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"KeyName: {this.KeyName} HashCode: {this.GetHashCode().ToString()}";
        }
    }
}
