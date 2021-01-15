using NUnit.Framework;
using Assignment2;
using System;

namespace TestLibrary
{
    /// <summary>
    /// StackTest - A class for testing the Stack class
    /// Stack - A class that is linked list of Nodes.
    ///         Contains the methods to treat the linked list as a Stack
    /// Assignment:     #2
    /// Course:         ADEV-3001
    /// Date Created:   Sept. 18th, 2019
    /// 
    /// Revision Log
    /// Who         When        Reason
    /// ----------- ----------- ---------------
    /// 
    /// @author: Scott Wachal
    /// @version 1.0
    /// </summary>
    [TestFixture]
    public class StackTest
    {
        #region Constructor Tests
        /// <summary>
        /// Test the constructor to ensure the default values are set properly.
        /// </summary>
        [Test]
        public void Constructor_head_is_null_Test()
        {
            Stack<Point> stack = new Stack<Point>();
            Assert.That(stack.Head, Is.Null);
        }
        #endregion

        #region Public Methods Test
        #region GetSize()
        /// <summary>
        /// Test GetSize() to ensure it returns zero on empty stack.
        /// </summary>
        [Test]
        public void GetSizeOnEmptyStackTest()
        {
            Stack<Point> stack = new Stack<Point>();

            Assert.That(stack.Size, Is.EqualTo(0));
        }
        #endregion


        #region Push()
        /// <summary>
        /// Test Push() to ensure node is added to stack and as the head
        /// </summary>
        [Test]
        public void Push_increases_size_by_1_Test()
        {
            Point newPoint = new Point(3, 5);
            Stack<Point> stack = new Stack<Point>();

            Assert.That(stack.Size, Is.EqualTo(0));

            stack.Push(newPoint);

            Assert.That(stack.Size, Is.EqualTo(1));
        }

        /// <summary>
        /// Test Push() to ensure node is added to head of stack.
        /// </summary>
        [Test]
        public void Push_Inserts_To_Head_Test()
        {
            Point newPoint = new Point(3, 5);
            Stack<Point> stack = new Stack<Point>();

            stack.Push(newPoint);

            Point headPoint = stack.Head.Element;
            Assert.That(headPoint, Is.EqualTo(newPoint));
            Assert.That(stack.Head.Previous, Is.Null);
        }

        /// <summary>
        /// Test Push() to ensure node is added to head of stack.
        /// </summary>
        [Test]
        public void Push_Inserts_To_Head_when_list_is_larger_Test()
        {
            Point point01 = new Point(3, 5);
            Point point02 = new Point(6, 7);
            Stack<Point> stack = new Stack<Point>();

            stack.Push(point02);
            stack.Push(point01);

            Point headPoint = stack.Head.Element;
            Point bottomPoint = stack.Head.Previous.Element;
            Assert.That(headPoint, Is.EqualTo(point01));
            Assert.That(bottomPoint, Is.EqualTo(point02));

            Assert.That(stack.Size, Is.EqualTo(2));
        }
        #endregion

        #region IsEmpty()
        /// <summary>
        /// Test IsEmpty() returns true on empty stack.
        /// </summary>
        [Test]
        public void IsEmptyOnEmptyStackTest()
        {
            Stack<Point> stack = new Stack<Point>();

            Assert.That(stack.IsEmpty(), Is.True);
        }

        /// <summary>
        /// Test IsEmpty() returns false on a stack with elements.
        /// </summary>
        [Test]
        public void IsEmptyOnStackWithElements()
        {
            Point point01 = new Point(3, 5);
            Stack<Point> stack = new Stack<Point>();
            stack.Push(point01);

            Assert.That(stack.IsEmpty(), Is.False);
        }
        #endregion

        #region Top()
        /// <summary>
        /// Test Top() throws an exception when called on an empty stack.
        /// </summary>
        [Test]
        public void Top_Throws_Exception_On_EmptyStack_Test()
        {
            Stack<Point> stack = new Stack<Point>();

            Assert.That(() => stack.Top(), Throws.Exception.TypeOf<System.ApplicationException>());
        }
        /// <summary>
        /// Test Top() to ensure it returns the top node.
        /// </summary>
        [Test]
        public void Top_returns_head_in_list_of_1_Test()
        {
            Point point01 = new Point(3, 5);
            Stack<Point> stack = new Stack<Point>();
            stack.Push(point01);

            Point returnedPoint = stack.Top();
            Point headPoint = stack.Head.Element;

            Assert.That(returnedPoint, Is.EqualTo(point01));
            Assert.That(headPoint, Is.EqualTo(returnedPoint));
        }

        /// <summary>
        /// Test Top() to ensure it returns the top node.
        /// </summary>
        [Test]
        public void Top_returns_head_in_larger_list_Test()
        {
            Point point01 = new Point(3, 5);
            Point point02 = new Point(3, 5);
            Point point03 = new Point(3, 5);
            Stack<Point> stack = new Stack<Point>();
            stack.Push(point03);
            stack.Push(point02);
            stack.Push(point01);

            Point returnedPoint = stack.Top();
            Point headPoint = stack.Head.Element;
            Point secondPoint = stack.Head.Previous.Element;
            Point thirdPoint = stack.Head.Previous.Previous.Element;
            Node<Point> lastNode = stack.Head.Previous.Previous;

            Assert.That(returnedPoint, Is.EqualTo(point01));
            Assert.That(headPoint, Is.EqualTo(returnedPoint));
            Assert.That(secondPoint, Is.EqualTo(point02));
            Assert.That(thirdPoint, Is.EqualTo(point03));

            // check that the last node still points to null!
            Assert.That(lastNode.Previous, Is.Null);
        }

        /// <summary>
        /// Test Top() to make sure it only returns the element and does not remove the element.
        /// </summary>
        [Test]
        public void Top_Does_Not_Remove_an_Element_Test()
        {
            Point newPoint = new Point(3, 5);
            Stack<Point> stack = new Stack<Point>();
            stack.Push(newPoint);

            Point returnedPoint = stack.Top();

            Assert.That(stack.Size, Is.EqualTo(1));
        }

        #endregion

        #region Pop()
        /// <summary>
        /// Test Pop() to ensure it throws and exception when called on an empty stack.
        /// </summary>
        [Test]
        public void Pop_Throws_Exception_On_EmptyStack_Test()
        {
            Stack<Point> stack = new Stack<Point>();

            Assert.That(() => stack.Pop(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Pop() to ensure it reduces the size by 1
        /// </summary>
        [Test]
        public void Pop_decreases_size_by_1_Test()
        {
            Point point01 = new Point(3, 5);
            Stack<Point> stack = new Stack<Point>();
            stack.Push(point01);

            Point returnedPoint = stack.Pop();

            Assert.That(stack.Size, Is.EqualTo(0));
        }

        /// <summary>
        /// Test Pop() to ensure it returns the top element.
        /// </summary>
        [Test]
        public void Pop_returns_top_element_in_list_of_1_Test()
        {
            Point point01 = new Point(3, 5);
            Stack<Point> stack = new Stack<Point>();
            stack.Push(point01);

            Node<Point> oldHead = stack.Head;
            Point oldHeadPoint = oldHead.Element;
            Point returnedPoint = stack.Pop();
            Node<Point> newHead = stack.Head;

            Assert.That(oldHeadPoint, Is.EqualTo(returnedPoint));
            Assert.That(returnedPoint, Is.EqualTo(point01));

            // list of 1 after a remove is an empty list
            Assert.That(stack.IsEmpty());
        }

        /// <summary>
        /// Test Pop() to ensure it returns the top element, in a bigger list.
        /// </summary>
        [Test]
        public void Pop_returns_top_element_in_larger_list_Test()
        {
            Point point01 = new Point(3, 5);
            Point point02 = new Point(2, 4);
            Point point03 = new Point(1, 3);

            Stack<Point> stack = new Stack<Point>();
            stack.Push(point03);
            stack.Push(point02);
            stack.Push(point01);

            Node<Point> oldHead = stack.Head;
            Point oldHeadPoint = oldHead.Element;
            Point returnedPoint = stack.Pop();
            Node<Point> newHead = stack.Head;
            Node<Point> lastNode = newHead.Previous;

            Assert.That(oldHeadPoint, Is.EqualTo(returnedPoint));
            Assert.That(returnedPoint, Is.EqualTo(point01));
            Assert.That(newHead.Element, Is.EqualTo(point02));
            Assert.That(lastNode.Element, Is.EqualTo(point03));
            Assert.That(lastNode.Previous, Is.Null);

            Assert.That(stack.Size, Is.EqualTo(2));
        }
        #endregion
        #region Clear()
        /// <summary>
        /// Test Clear() to ensure it returns size of zero and null head.
        /// </summary>
        [Test]
        public void Clear_on_populated_stack_sets_size_to_0_head_becomes_null_Test()
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(3, 5));
            stack.Push(new Point(2, 4));
            stack.Clear();
            Assert.That(stack.Head, Is.Null);
            Assert.That(stack.IsEmpty());
        }
        #endregion
        #endregion
    }
}