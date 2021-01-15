using NUnit.Framework;
using Assignment1;

namespace TestLibrary
{
    /// <summary>
    /// IMPORTANT NOTE: DO NOT CHANGE THE TEST CODE!! EVER. :)
    /// NodeTest - A class for testing a Node class
    /// Node - A class that is the building block of several data structures including the linked list.
    ///         Holds generic element data and links to a previous Node and a next Node, if they are available
    /// 
    /// Assignment:     #1
    /// Course:         ADEV-3001
    /// Date Created:   August. 31, 2019
    /// 
    /// Revision Log
    /// Who         When        Reason
    /// ----------- ----------- ---------------
    /// 
    /// @author: Scott Wachal
    /// @version 1.0
    /// </summary>
    [TestFixture]
    public class NodeTest
    {

        #region Constructor Tests
        /// <summary>
        /// Test the empty constructor to ensure the values are set to the proper defaults.
        /// </summary>
        [Test]
        public void Empty_Constructor_Test()
        {
            Node<Employee> node = new Node<Employee>();
            Assert.That(node, Is.Not.Null);
            Assert.That(node.Element, Is.EqualTo(null));
            Assert.That(node.Next, Is.Null);
            Assert.That(node.Previous, Is.Null);

        }

        /// <summary>
        /// Test the parameter constructor to ensure the values are being set properly in the created instance.
        /// </summary>
        [Test]
        public void AllParameters_Constructor_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            Node<Employee> previousNode = new Node<Employee>(employee1, null, null);
            Node<Employee> nextNode = new Node<Employee>(employee2, null, null);

            Node<Employee> node = new Node<Employee>(employee3, previousNode, nextNode);

            Assert.That(node, Is.Not.Null);
            Assert.That(node.Element, Is.EqualTo(employee3));
            Assert.That(node.Next, Is.EqualTo(nextNode));
            Assert.That(node.Previous, Is.EqualTo(previousNode));

        }
        #endregion

        #region Properties Test
        /// <summary>
        /// Test the Element property to ensure that it is being set and retrieved properly.
        /// </summary>
        [Test]
        public void Element_Test()
        {
            Employee employeeTest = new Employee(1);

            Node<Employee> node = new Node<Employee>();
            node.Element = employeeTest;

            Assert.That(node.Element, Is.EqualTo(employeeTest));

        }

        /// <summary>
        /// Test the Previous property to ensure it is being set and retrieved properly.
        /// </summary>
        [Test]
        public void Previous_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Node<Employee> previousNode = new Node<Employee>(employee1, null, null);
            Node<Employee> testNode = new Node<Employee>(employee2, null, null);

            testNode.Previous = previousNode;

            Assert.That(testNode.Previous, Is.EqualTo(previousNode));

        }

        /// <summary>
        /// Test the Next property to ensure it is being set and retrieved properly.
        /// </summary>
        [Test]
        public void Next_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Node<Employee> nextNode = new Node<Employee>(employee1, null, null);
            Node<Employee> testNode = new Node<Employee>(employee2, null, null);

            testNode.Next = nextNode;

            Assert.That(testNode.Next, Is.EqualTo(nextNode));

        }
        #endregion

    }
}
