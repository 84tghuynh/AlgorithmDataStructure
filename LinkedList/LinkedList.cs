using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class LinkedList<T> where T : IComparable<T>
    {

        /////////////////////////
        ///     Milestone 1   ///
        ///////////////////////// 
        
        /// <summary>
        /// Get/Set the head node
        /// </summary>
        public Node<T> Head { get; set; }

        /// <summary>
        /// Get/Set the tail node
        /// </summary>
        public Node<T> Tail { get; set; }

        /// <summary>
        /// Get/Set the size of LinkedList
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Constructor, initializes private fields
        /// </summary>
        public LinkedList()
        {
            Clear();
        }

        /// <summary>
        /// Return true if the list is empty, else return false
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Size == 0;
       
        /// <summary>
        /// Creates a new Node with the new element and adds it to the head of the list.
        /// Empty all elements from the list
        /// </summary>
        /// <param name="element"></param>
        public void AddFirst(T element)
        {
            Node<T> node = new Node<T>(element, previousNode: null, nextNode: Head);
           
            if (!IsEmpty()) this.Head.Previous = node;
            this.Head = node;

            if (IsEmpty()) this.Tail = node;
            this.Size += 1;
        }

        /// <summary>
        /// Adds new element to the tail of the list
        /// </summary>
        /// <param name="element"></param>
        public void AddLast(T element)
        {
            Node<T> node = new Node<T>(element, previousNode: Tail, nextNode: null);
            if (!IsEmpty()) this.Tail.Next = node;
            this.Tail = node;

            if (IsEmpty()) this.Head = node;
            this.Size += 1;
        }

        /// <summary>
        /// Set head node element to parameter value
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T SetFirst(T element)
        {
            if (IsEmpty())
            {
                throw new System.ApplicationException();
            }

            T headElement = this.Head.Element;
            this.Head.Element = element;
            return headElement;
        }

        /// <summary>
        /// Set tail node element to parameter value
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T SetLast(T element)
        {
            if (IsEmpty())
            {
                throw new System.ApplicationException();
            }

            T tailElement = this.Tail.Element;
            this.Tail.Element = element;
            return tailElement;
        }

        /// <summary>
        /// Return the element in the head node
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            if (IsEmpty())
            {
                throw new System.ApplicationException();
            }

            return this.Head.Element;
        }

        /// <summary>
        /// Return the element in the tail node
        /// </summary>
        /// <returns></returns>
        public T GetLast()
        {
            if (IsEmpty())
            {
                throw new System.ApplicationException();
            }

            return this.Tail.Element;
        }

        /// <summary>
        /// Empty all elements from the list
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
            this.Size = 0;
        }


        /////////////////////////
        ///     Milestone 2   ///
        ///////////////////////// 
        
        /// <summary>
        /// Remove the head node
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst() 
        {
           return RemoveNode(GetNodeInLinkedList(1, 1, this.Head)).Element;
           
        }

        /// <summary>
        /// Remove the tail node
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            return RemoveNode(GetNodeInLinkedList(1, this.Size, this.Head)).Element;
           
        }

        /// <summary>
        /// Return the element at the position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Get(int position)
        {
           Node<T> foundNode = GetNodeInLinkedList(1, position, this.Head);

           return foundNode.Element;
        }

        /// <summary>
        /// Remove the node at the numeric position specified
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Remove(int position)
        {
            return RemoveNode(GetNodeInLinkedList(1, position, this.Head)).Element;
        }

        /// <summary>
        /// Change specified node to element in parameter 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Set(T element, int position)
        {

            Node<T> foundNode = GetNodeInLinkedList(1, position, this.Head);
            T currentElement = foundNode.Element;

            foundNode.Element = element;

            return currentElement;
        }

        /// <summary>
        /// Add new element after the node at the provided position.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="position"></param>
        public void AddAfter(T element, int position)
        {
            Node<T> newNode = new Node<T>(element);

            Node<T> foundNode = GetNodeInLinkedList(1, position, this.Head);

            AddNode(element, foundNode, foundNode.Next);
        }

        /// <summary>
        /// Add new element before the node at the provided position.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="position"></param>
        public void AddBefore(T element, int position)
        {
            Node<T> foundNode = GetNodeInLinkedList(1, position, this.Head);
            AddNode(element, foundNode.Previous, foundNode);
        }

        /// <summary>
        /// Add a node between prevNode and nextNode
        /// </summary>
        /// <param name="element"></param>
        /// <param name="prevNode"></param>
        /// <param name="nextNode"></param>
        private void AddNode(T element, Node<T> prevNode, Node<T> nextNode)
        {
            if(prevNode == null)
            {
                AddFirst(element);
            }
            else if(nextNode == null)
            {
                AddLast(element);
            }
            else
            {
                Node<T> newNode = new Node<T>(element);

                newNode.Previous = prevNode;
                prevNode.Next = newNode;

                newNode.Next = nextNode;
                nextNode.Previous = newNode;
               
                this.Size += 1;
            }
        }

        /// <summary>
        /// Get Node at position
        /// This method will be use in the other methods many times;
        /// startPos = 1:  find node at the beginning of LinkedList; 
        /// foundNode = this.Head : Use "this.Head" node as a starting point of searching process
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="position"></param>
        /// <param name="foundNode"></param>
        /// <returns></returns>
        private Node<T> GetNodeInLinkedList(int startPos, int position, Node<T> foundNode)
        {
            if (IsEmpty() || position < 1 || position > this.Size)
            {
                throw new System.ApplicationException();
            }
            return GetNodeRecursively(startPos, position, foundNode);
        }

        /// <summary>
        /// Get node at postion, startPos = 1, foundNode = this.Head
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="position"></param>
        /// <param name="foundNode"></param>
        /// <returns></returns>
        private Node<T> GetNodeRecursively(int startPos, int position, Node<T> foundNode)
        {
            if (startPos != position) return this.GetNodeRecursively(startPos + 1, position, foundNode.Next);
            else return foundNode;
        }

        /// <summary>
        /// Remove a foundNode was found by position
        /// </summary>
        /// <param name="foundNode"></param>
        /// <returns></returns>
        private Node<T> RemoveNode(Node<T> foundNode)
        {
            if (foundNode.Previous == null && foundNode.Next == null) Clear();
            else
            {

                if (foundNode.Previous == null && foundNode.Next != null)
                {
                    this.Head = foundNode.Next;
                    this.Head.Previous = null;
                }
                else if (foundNode.Previous != null && foundNode.Next == null)
                {
                    this.Tail = foundNode.Previous;
                    this.Tail.Next = null;
                }
                else if (foundNode.Previous != null && foundNode.Next != null)
                {
                    foundNode.Previous.Next = foundNode.Next;
                    foundNode.Next.Previous = foundNode.Previous;
                }

                this.Size -= 1;
                foundNode.Next = null;
                foundNode.Previous = null;
            }

            return foundNode;
        }

        ////////////////////////////
        ////    Milestone 3    /////
        ////////////////////////////

        /// <summary>
        /// Return the element in the node containing the element specified (does not use position!)
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Get(T element)
        {

            Node<T> foundNode = FindNodeByElementRecursively(element, this.Head);

            if(foundNode.Element.CompareTo(element) != 0) throw new System.ApplicationException();

            return element;
        }

        /// <summary>
        /// Add new element after the node containing the ‘oldelement’ specified (does not use position!)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="oldElement"></param>

        public void AddAfter(T element, T oldElement)
        {
            Node<T> foundNode = FoundNodeElement(oldElement);
            AddNode(element, foundNode, foundNode.Next);
        }

        /// <summary>
        /// Add new element after the node containing the ‘oldelement’ specified (does not use position!)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="oldElement"></param>
        public void AddBefore(T element, T oldElement)
        {
            Node<T> foundNode = FoundNodeElement(oldElement);
            AddNode(element, foundNode.Previous, foundNode);
        }


        /// <summary>
        /// Remove the node containing the element specified. (does not use position!)
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Remove(T element)
        {
            return RemoveNode(FoundNodeElement(element)).Element;
            //Node <T> foundNode = FoundNodeElement(element);
            //foundNode = RemoveNode(foundNode);

            //return foundNode.Element;
        }

        /// <summary>
        /// Change the element on the node containing the oldelement with the element passed and 
        /// return the old element. (does not use position!)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="oldElement"></param>
        /// <returns></returns>
        public T Set(T element, T oldElement)
        {
            Node<T> foundNode = FoundNodeElement(oldElement);

            foundNode.Element = element;

            return oldElement;
        }
        /// <summary>
        /// Add the element into the linked list in natural ascending order. Note that all elements used by LinkedList *MUST* implement the comparable interface, so please use compareTo() here.
        /// Example Insert:
        /// Current list is 1 5 8 15, adding 7 would add at
        /// 1 5 7 8 15, because 8 is greater than 7.
        /// Important note, if the list is NOT already in ascending order, this will not change the algorithm.
        /// Example Insert: 
        /// 3 150 8 1 1001, adding 7 would add at
        /// 3 7 150 8 1 1001.  Because 7 is smaller than 150, the first number to be greater than 7.
        /// </summary>
        /// <param name="element"></param>
        public void Insert(T element)
        {
            Node<T> node = Head;

            while (node != null && element.CompareTo(node.Element) > 0)
            {
                node = node.Next;
            }

            if (node == null)
            { // list was empty, or element was largest
                AddLast(element);
            }
            else
            {
                AddNode(element, node.Previous, node);
            }

            //if (IsEmpty()) AddFirst(element);
            //else
            //{
            //    Node<T> firstNode = FindFirstNodeGreaterByElement(element, this.Head);

            //    if (element.CompareTo(firstNode.Element) > 0) AddLast(element);
            //    else
            //    {
            //        AddNode(element, firstNode.Previous, firstNode);
            //    }
            //}
        }

        /// <summary>
        /// Sort the elements into ascending order. 
        /// You can use any algorithms you want to achieve this (Example of an easy sorting algorithm is: bubble sort)
        /// </summary>

        public void SortAscending() 
        {
            Node<T> node = Head;
            Clear();
            while (node != null)
            {
                Insert(node.Element);
                node = node.Next;
            }

            //Node<T> smallestNode, iNode;

            //for(int i = 1; i < this.Size; i++)
            //{
            //    smallestNode = findNodeHasSmallestElement(i);
            //    iNode = GetNodeInLinkedList(1, i, this.Head);

            //    if (smallestNode.Element.CompareTo(iNode.Element) < 0)
            //    {
            //        T tempElement = iNode.Element;

            //        iNode.Element = smallestNode.Element;
            //        smallestNode.Element = tempElement;
            //    }

            //}

        }

        /// <summary>
        /// Find Node has smallest Element from start position to the end of the list
        /// </summary>
        /// <param name="startPos"></param>
        /// <returns></returns>
        public Node<T> findNodeHasSmallestElement(int startPos)
        {

            Node<T> foundNode = null;
            for (int i=startPos; i<= Size; i++)
            {
                foundNode = GetNodeInLinkedList(1, i, this.Head);
                for(int j=i+1; j<Size; j++)
                {
                    Node<T> tempNode = GetNodeInLinkedList(1, j, this.Head);

                    if (foundNode.Element.CompareTo(tempNode.Element) > 0) foundNode = tempNode;
                }

            }
            
            return foundNode;
        }


        public int GetPositionOfNode(Node<T> node)
        {
            if (IsEmpty())
            {
                throw new System.ApplicationException();
            }

            Node<T> tempNode = Head;
            int pos = 0;
            bool flag = false;

            while (tempNode != null)
            {
                if (tempNode.Element.CompareTo(node.Element) != 0)
                {
                    pos +=1;
                  //  Console.WriteLine("{0}", pos);
                    tempNode = tempNode.Next;
                }
                else
                {
                    flag = true;
                    break;
                }
            }

            if (!flag) pos = -1;

            return pos;
        }




        /// <summary>
        /// Find the first node has element greater the element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="firstNode"></param>
        /// <returns></returns>
        public Node<T> FindFirstNodeGreaterByElement(T element, Node<T> firstNode)
        {
            if (element.CompareTo(firstNode.Element) > 0 && firstNode.Next != null) return FindFirstNodeGreaterByElement(element, firstNode.Next);
            return firstNode;
        }

        /// <summary>
        ///  Find the Node with Element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Node<T> FoundNodeElement(T element)
        {
            if (element == null) throw new System.ArgumentNullException();
            Node<T> foundNode = FindNodeByElementRecursively(element, this.Head);
            if (foundNode.Element.CompareTo(element) != 0) throw new System.ApplicationException();

            return foundNode;
        }

        /// <summary>
        /// Find the node by Element by recursive
        /// </summary>
        /// <param name="element"></param>
        /// <param name="firstNode"></param>
        /// <returns></returns>
        private Node<T> FindNodeByElementRecursively(T element, Node<T> firstNode)
        {
            if (IsEmpty()) throw new System.ApplicationException();

            if (element.CompareTo(firstNode.Element) != 0 && firstNode.Next != null) return FindNodeByElementRecursively(element, firstNode.Next);
            return firstNode;
        }
    }
}
