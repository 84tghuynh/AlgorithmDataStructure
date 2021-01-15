using NUnit.Framework;
using Assignment3;
using System;

namespace TestLibrary
{

    /// <summary>
    /// QueueTest - A class for testing the Queue class
    /// 
    /// Assignment:     #3
    /// Course:         ADEV-3001
    /// Date Created:   March 20th, 2018
    /// 
    /// Revision Log
    /// Who         When        Reason
    /// ----------- ----------- ---------------
    /// 
    /// @author: Scott Wachal
    /// @version 1.0
    /// </summary>
    [TestFixture]
    public class QueueTest
    {

        #region Constructor Tests
        /// <summary>
        /// Test the constructor to ensure the default values are set properly.
        /// </summary>
        [Test]
        public void Constructor_head_and_tail_is_null_Test()
        {
            Queue<Point> queue = new Queue<Point>();
            Assert.That(queue.Head, Is.Null);
            Assert.That(queue.Tail, Is.Null);
        }

        #endregion

        #region Public Methods Test

        #region GetSize()
        /// <summary>
        /// Test GetSize() to ensure it returns zero on empty queue.
        /// </summary>
        [Test]
        public void GetSizeOnEmptyQueueTest()
        {
            Queue<Point> queue = new Queue<Point>();

            Assert.That(queue.Size, Is.EqualTo(0));
        }
        #endregion

        #region Enqueue()
        /// <summary>
        /// Test Enqueue() to ensure node is added to queue and size increases
        /// </summary>
        [Test]
        public void Enqueue_increases_size_by_1_Test()
        {
            Point newPoint = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();

            Assert.That(queue.Size, Is.EqualTo(0));

            queue.Enqueue(newPoint);

            Assert.That(queue.Size, Is.EqualTo(1));
        }

        /// <summary>
        /// Test Enqueue() to ensure node is added and is the new head/tail
        /// </summary>
        [Test]
        public void Enqueue_Inserts_To_Head_Test()
        {
            Point newPoint = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();

            queue.Enqueue(newPoint);

            Point headPoint = queue.Head.Element;
            Point tailPoint = queue.Head.Element;

            Assert.That(headPoint, Is.EqualTo(newPoint));
            Assert.That(tailPoint, Is.EqualTo(newPoint));
            Assert.That(queue.Head.Next, Is.Null);
            Assert.That(queue.Tail.Next, Is.Null);
        }

        /// <summary>
        /// Test Enqueue() to ensure node is added to the queue.
        /// </summary>
        [Test]
        public void Enqueue_Inserts_To_Tail_when_list_is_larger_Test()
        {
            Point point01 = new Point(3, 5);
            Point point02 = new Point(6, 7);
            Queue<Point> queue = new Queue<Point>();

            queue.Enqueue(point02);
            queue.Enqueue(point01);

            Point headPoint = queue.Head.Element;
            Point bottomPoint = queue.Tail.Element;
            Assert.That(headPoint, Is.EqualTo(point02));
            Assert.That(bottomPoint, Is.EqualTo(point01));

            Assert.That(queue.Size, Is.EqualTo(2));
        }
        #endregion

        #region IsEmpty()
        /// <summary>
        /// Test IsEmpty() returns true on empty queue.
        /// </summary>
        [Test]
        public void IsEmptyOnEmptyQueueTest()
        {
            Queue<Point> queue = new Queue<Point>();

            Assert.That(queue.IsEmpty(), Is.True);
        }

        /// <summary>
        /// Test IsEmpty() returns false on a queue with elements.
        /// </summary>
        [Test]
        public void IsEmptyOnQueueWithElements()
        {
            Point point01 = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(point01);

            Assert.That(queue.IsEmpty(), Is.False);
        }
        #endregion

        #region Front()
        /// <summary>
        /// Test Front() throws an exception when called on an empty queue.
        /// </summary>
        [Test]
        public void Front_Throws_Exception_On_EmptyQueue_Test()
        {
            Queue<Point> queue = new Queue<Point>();

            Assert.That(() => queue.Front(), Throws.Exception.TypeOf<ApplicationException>());
        }
        /// <summary>
        /// Test Front() to ensure it returns the front node.
        /// </summary>
        [Test]
        public void Front_returns_head_in_list_of_1_Test()
        {
            Point point01 = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(point01);

            Point returnedPoint = queue.Front();
            Point headPoint = queue.Head.Element;
            Point tailPoint = queue.Tail.Element;

            Assert.That(returnedPoint, Is.EqualTo(point01));
            Assert.That(headPoint, Is.EqualTo(returnedPoint));
            Assert.That(tailPoint, Is.EqualTo(returnedPoint));
        }

        /// <summary>
        /// Test Front() to ensure it returns the head node.
        /// </summary>
        [Test]
        public void Front_returns_head_in_larger_list_Test()
        {
            Point point01 = new Point(1, 5);
            Point point02 = new Point(2, 5);
            Point point03 = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(point03);
            queue.Enqueue(point02);
            queue.Enqueue(point01);

            Point returnedPoint = queue.Front();
            Point headPoint = queue.Head.Element;

            Assert.That(returnedPoint, Is.EqualTo(point03));
            Assert.That(headPoint, Is.EqualTo(returnedPoint));

            // check integrity of queue:
            Point secondPoint = queue.Head.Next.Element;
            Point thirdPoint = queue.Head.Next.Next.Element;
            Node<Point> tailNode = queue.Head.Next.Next;

            Assert.That(secondPoint, Is.EqualTo(point02));
            Assert.That(thirdPoint, Is.EqualTo(point01));
            Assert.That(thirdPoint, Is.EqualTo(tailNode.Element));

            // check that the tailNode still points to null!
            Assert.That(tailNode.Next, Is.Null);
        }

        /// <summary>
        /// Test Front() to make sure it only returns the element and does not remove the element.
        /// </summary>
        [Test]
        public void Front_Does_Not_Remove_an_Element_Test()
        {
            Point newPoint = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(newPoint);

            Point returnedPoint = queue.Front();

            Assert.That(queue.Size, Is.EqualTo(1));
        }

        #endregion

        #region Dequeue()
        /// <summary>
        /// Test Dequeue() to ensure it throws and exception when called on an empty queue.
        /// </summary>
        [Test]
        public void Dequeue_Throws_Exception_On_EmptyQueue_Test()
        {
            Queue<Point> queue = new Queue<Point>();

            Assert.That(() => queue.Dequeue(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Dequeue() to ensure it reduces the size by 1
        /// </summary>
        [Test]
        public void Dequeue_decreases_size_by_1_Test()
        {
            Point point01 = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(point01);

            Point returnedPoint = queue.Dequeue();

            Assert.That(queue.Size, Is.EqualTo(0));
        }

        /// <summary>
        /// Test Dequeue() to ensure it returns the front element.
        /// </summary>
        [Test]
        public void Dequeue_returns_head_element_in_list_of_1_Test()
        {
            Point point01 = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(point01);

            Node<Point> oldHead = queue.Head;
            Point oldHeadPoint = oldHead.Element;
            Point returnedPoint = queue.Dequeue();
            Node<Point> newHead = queue.Head;

            Assert.That(oldHeadPoint, Is.EqualTo(returnedPoint));
            Assert.That(returnedPoint, Is.EqualTo(point01));

            // list of 1 after a remove is an empty list
            Assert.That(queue.IsEmpty());
        }

        /// <summary>
        /// Test Dequeue() sets head and tail to null when removing the last node in the queue
        /// </summary>
        [Test]
        public void Dequeue_sets_head_and_tail_to_null_in_list_of_1_Test()
        {
            Point point = new Point(3, 5);
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(point);
            Assert.That(queue.Size.Equals(1));
            queue.Dequeue();
            Assert.That(queue.Head, Is.Null);
            Assert.That(queue.Tail, Is.Null);
            Assert.That(queue.Size.Equals(0));

            // list of 1 after a remove is an empty list
            Assert.That(queue.IsEmpty());
        }

        /// <summary>
        /// Test Dequeue() to ensure it returns the head element, in a bigger list.
        /// </summary>
        [Test]
        public void Dequeue_returns_head_element_in_larger_list_Test()
        {
            Point point01 = new Point(3, 5);
            Point point02 = new Point(2, 4);
            Point point03 = new Point(1, 3);

            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(point03);
            queue.Enqueue(point02);
            queue.Enqueue(point01);

            Node<Point> oldHead = queue.Head;
            Point oldHeadPoint = oldHead.Element;
            Point returnedPoint = queue.Dequeue();
            Node<Point> newHead = queue.Head;
            Node<Point> lastNode = newHead.Next;
            Node<Point> tailNode = queue.Tail;

            Assert.That(oldHeadPoint, Is.EqualTo(returnedPoint));
            Assert.That(returnedPoint, Is.EqualTo(point03));
            Assert.That(newHead.Element, Is.EqualTo(point02));
            Assert.That(lastNode.Element, Is.EqualTo(point01));
            Assert.That(lastNode.Element, Is.EqualTo(tailNode.Element));
            Assert.That(lastNode.Next, Is.Null);

            Assert.That(queue.Size, Is.EqualTo(2));
        }
        #endregion

        #region Clear()
        /// <summary>
        /// Test Clear() to ensure it returns size of zero and null head.
        /// </summary>
        [Test]
        public void Clear_on_populated_queue_sets_size_to_0_head_becomes_null_Test()
        {
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(3, 5));
            queue.Enqueue(new Point(2, 4));
            queue.Clear();
            Assert.That(queue.Head, Is.Null);
            Assert.That(queue.IsEmpty());
        }
        #endregion

        #endregion

    }

}