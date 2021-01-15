using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Queue<T>
    {

        /// <summary>
        /// Get/Set the head node
        /// </summary>
        public Node<T> Head { get; set; }

        /// <summary>
        /// Get/Set the tail node
        /// </summary>
        public Node<T> Tail { get; set; }

        /// <summary>
        /// Get/Set the size of Queue
        /// </summary>
        public int Size { get; set; }

        public Queue()
        {
            Clear();
        }

        /// <summary>
        /// Return true if the Queue is empty, else return false
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Size == 0;

        /// <summary>
        /// Empty all elements from the Queue
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
            this.Size = 0;
        }

        /// <summary>
        /// Creates a new Node with a new element and adds it to the tail of the queue. 
        /// The old tail will now point to the new tail.
        /// </summary>
        /// <param name="element"></param>

        public void Enqueue(T element)
        {
            
            Node<T> node = new Node<T>(element);

            if (IsEmpty())
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            this.Size++;
        }

        /// <summary>
        /// Returns the front element in the queue (next to be removed) without removing it from the data structure
        /// </summary>
        /// <returns></returns>

        public T Front() => IsEmpty() ? throw new ApplicationException() : Head.Element;

        /// <summary>
        /// Returns the front element on the queue, removing it from the data structure. 
        /// The new Head will point to the next person in line.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty()) throw new ApplicationException();

            T oldElement = this.Head.Element;

            this.Head = this.Head.Next;
            this.Size--;

            if (IsEmpty()) this.Tail = this.Head;
            

            return oldElement;
        }
       

    }
}
