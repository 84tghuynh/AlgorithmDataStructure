using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Stack<T> //where T : IComparable<T>
    {
        /// <summary>
        /// Maintains Head - Points to the top node in the stack 
        /// (or null if there are no nodes)
        /// </summary>
        public Node<T> Head { get; set; }

        /// <summary>
        /// Maintains Size – Count of the number of nodes in the list, 
        /// zero when the list is empty
        /// </summary>
        public int Size { get; set; }

        public Stack()
        {
            this.Clear();

        }

        /// <summary>
        /// Return true if the stack is empty, else return false
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Size == 0;

        /// <summary>
        /// Empty all elements from the list
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.Size = 0;
        }

        /// <summary>
        /// Creates a new Node with the new element 
        /// and adds it to the top of the stack
        /// </summary>
        /// <param name="element"></param>
        public void Push(T element)
        {
            Node<T> node = new Node<T>(element);

            //node.Previous = Head;
            this.Head = new Node<T>(element, Head,null);
            this.Size++;
        }

        /// <summary>
        /// Returns the top element on the stack 
        /// without removing it from the data structure
        /// </summary>
        /// <returns></returns>
        public T Top() => IsEmpty() ? throw new ApplicationException() : Head.Element;
        //{
        //    if (IsEmpty())
        //    {
        //        throw new System.ApplicationException();
        //    }

        //    return this.Head.Element;    
        //}
        /// <summary>
        /// Returns the top element on the stack, 
        /// removing it from the data structure
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new System.ApplicationException();
            }
            T oldElement = this.Head.Element;
            this.Head = Head.Previous;
            this.Size--;

            return oldElement;

        }
    }
}
