using NUnit.Framework;
using System;
using Assignment1;

namespace TestLibrary
{
    /// <summary>
    /// IMPORTANT NOTE: DO NOT CHANGE THE TEST CODE!! EVER. :)
    /// LinkedListTest - A class for testing the LinkedList class
    /// LinkedList - A class for creating and manipulating a doubly linked list of nodes containing generic data of type T.
    /// 
    /// Assignment:     #1
    /// Course:         ADEV-3001
    /// Date Created:   August. 31, 2019
    /// 
    /// @author: Scott Wachal
    /// @version 1.0
    /// </summary>
    [TestFixture]
    public class LinkedListTest
    {
        #region Milestone 1

        #region Constructor Tests, (requires .Head, .Tail, .Size, IsEmpty())
        /// <summary>
        /// Test the constructor to ensure the default values are set properly.
        /// </summary>
        [Test]
        public void new_constructor_has_size_of_zero_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Size, Is.EqualTo(0));
        }

        [Test]
        /// <summary>
        /// Test GetHead returns null when a new constructor is called.
        /// </summary>
        public void GetHead_is_null_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Head, Is.EqualTo(null));
        }

        [Test]
        /// <summary>
        /// Test GetTail returns null when a new constructor is called.
        /// </summary>
        public void GetTail_is_null_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// Test IsEmpty() should return true on an empty list.
        /// </summary>
        [Test]
        public void IsEmpty_is_true_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.IsEmpty(), Is.True);
        }
        #endregion

        #region AddFirst(), requires: .Size / GetHead() / GetTail()
        /// <summary>
        /// Test AddFirst() to ensure node is added to list.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_count_increases_from_0_to_1_Test()
        {
            Employee addedEmployee = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Size, Is.EqualTo(0));

            list.AddFirst(addedEmployee);

            Assert.That(list.Size, Is.EqualTo(1));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_Head_Updated_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Head, Is.EqualTo(null));

            list.AddFirst(employee1);

            Assert.That(list.Head.Element, Is.EqualTo(employee1));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the tail pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_Tail_Updated_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Tail, Is.EqualTo(null));

            list.AddFirst(employee1);

            Assert.That(list.Tail.Element, Is.EqualTo(employee1));
        }

        /// <summary>
        /// Test AddFirst() to ensure it can handle null being added to list.
        /// </summary>
        [Test]
        public void AddFirst_null_element_is_allowed_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(null);

            Assert.That(list.Size, Is.EqualTo(1));
            Assert.That(list.GetFirst(), Is.Null);
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head pointer is updated when many objects are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_larger_Existing_list_Head_tail_and_size_Updated_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Head, Is.EqualTo(null));

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            Assert.That(list.Head.Element, Is.EqualTo(employee1)); // 1 , 2, 3, head should be 1
            Assert.That(list.Tail.Element, Is.EqualTo(employee3)); // 1 , 2, 3, tail should be 3

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        #endregion

        #region .Size
        /// <summary>
        /// Test .Size to make sure it returns the proper size; mostly for fun here. :)
        /// </summary>
        [Test]
        public void GetSize_returns_correct_value_after_random_adds_Test()
        {
            Random rnd = new Random();
            int numberOfElements = rnd.Next(1, 50);

            Employee employee = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();

            for (int i = 0; i < numberOfElements; i++)
            {
                list.AddFirst(employee);
            }

            Assert.That(list.Size, Is.EqualTo(numberOfElements));
        }
        #endregion

        #region GetFirst() and GetLast()

        /// <summary>
        /// Test that GetFirst throws an exception when called on an empty list, because Null.Element doesn't exist!
        /// </summary>
        [Test]
        public void GetFirst_on_emptylist_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.GetFirst(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test that GetFirst returns the head's element
        /// </summary>
        [Test]
        public void GetFirst_on_existinglist_returns_head_element_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(new Employee(1));

            Assert.That(list.Head.Element, Is.EqualTo(list.GetFirst()));
        }

        /// <summary>
        /// Test that GetLast throws an exception when called on an empty list, because Null.Element doesn't exist!
        /// </summary>
        [Test]
        public void GetLast_on_emptylist_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.GetLast(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test that GetLast returns the tail's element
        /// </summary>
        [Test]
        public void GetLast_on_existinglist_returns_tail_element_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(new Employee(1));

            Assert.That(list.Tail.Element, Is.EqualTo(list.GetLast()));
        }
        #endregion

        #region IsEmpty()
        /// <summary>
        /// Test IsEmpty() should return false on a list containing nodes.
        /// </summary>
        [Test]
        public void IsEmpty_returns_false_on_existinglist_Test()
        {
            Employee employee = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(list.IsEmpty(), Is.False);
        }
        /// <summary>
        /// Test IsEmpty() should return true on a list containing no nodes.
        /// </summary>
        [Test]
        public void IsEmpty_returns_true_on_empty_list_Test()
        {
            Employee employee = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.IsEmpty(), Is.True);
        }
        #endregion

        #region Clear()
        /// <summary>
        /// Test that Clear() empties a list.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            list.AddFirst(employee2);
            list.AddFirst(employee1);

            Assert.That(list.Size, Is.EqualTo(3));

            list.Clear();

            Assert.That(list.IsEmpty, Is.EqualTo(true));
        }

        /// <summary>
        /// Test that calling Clear() on an empty list doesn't throw an exception.
        /// </summary>
        [Test]
        public void ClearEmptyListTest()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            try
            {
                list.Clear();
            }
            catch (Exception)
            {
                Assert.Fail("Clear() should not have thrown exception.");
            }

            Assert.Pass("Clear() did not throw exception.");
        }
        #endregion

        #region SetFirst(element)
        /// <summary>
        /// Test SetFirst() on an empty list raises an exception.
        /// </summary>
        [Test]
        public void SetFirst_on_emptyList_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.SetFirst(employee1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test SetFirst() replaces element on the head node on list of 1
        /// </summary>
        [Test]
        public void SetFirst_on_list_of_1_replaces_head_element_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);

            list.SetFirst(employee2);

            Assert.That(list.GetFirst(), Is.EqualTo(employee2));
            Assert.That(list.Size, Is.EqualTo(1)); //ensure size doesn't change!
        }

        /// <summary>
        /// Test SetFirst() returns the element that has been replaced.
        /// </summary>
        [Test]
        public void SetFirst_Returns_ReplacedElement_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);

            var returnedData = list.SetFirst(employee2);

            Assert.That(returnedData, Is.EqualTo(employee1));
        }


        /// <summary>
        /// Test SetFirst() does_not_impact_an_existing_list (head/tail/size/pointers)
        /// </summary>
        [Test]
        public void SetFirst_does_not_impact_an_existing_list_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);
            Employee employee4 = new Employee(4);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedData = list.SetFirst(employee4);

            Assert.That(returnedData, Is.EqualTo(employee1));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        #endregion

        #region SetLast(element)

        /// <summary>
        /// Test SetLast() on an empty list raises an exception.
        /// </summary>
        [Test]
        public void SetLast_on_emptyList_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.SetLast(employee1), Throws.Exception.TypeOf<ApplicationException>());
            Assert.That(list.Size, Is.EqualTo(0)); //ensure size doesn't change!
        }

        /// <summary>
        /// Test SetLast() replaces element on the tail node.
        /// </summary>
        [Test]
        public void SetLast_on_existingList_updates_tail_element_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);
            list.AddFirst(employee2);

            list.SetLast(employee3);

            Assert.That(list.GetLast(), Is.EqualTo(employee3));
        }

        /// <summary>
        /// Test SetLast() returns the element that has been replaced.
        /// </summary>
        [Test]
        public void SetLast_returns_replaced_element_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);
            list.AddFirst(employee2);

            var returnedData = list.SetLast(employee3);

            Assert.That(returnedData, Is.EqualTo(employee1));
        }


        /// <summary>
        /// Test SetLast() does_not_impact_an_existing_list (head/tail/size/pointers)
        /// </summary>
        [Test]
        public void SetLast_does_not_impact_an_existing_list_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);
            Employee employee4 = new Employee(4);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedData = list.SetLast(employee4);

            Assert.That(returnedData, Is.EqualTo(employee3));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        #endregion
        #region AddLast()
        /// <summary>
        /// Test AddLast() to ensure node is added to list.
        /// </summary>
        [Test]
        public void AddLast_to_emptyList_count_increases_Test()
        {
            Employee addedEmployee = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(addedEmployee);

            Assert.That(list.Size, Is.EqualTo(1));
        }

        /// <summary>
        /// Test AddLast() to ensure node is added to list.
        /// </summary>
        [Test]
        public void AddLast_to_emptyList_tail_updated_Test()
        {
            Employee addedEmployee = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(addedEmployee);

            Assert.That(list.GetLast(), Is.EqualTo(addedEmployee));
        }
        /// <summary>
        /// Test AddLast() to ensure node is added to list.
        /// </summary>
        [Test]
        public void AddLast_to_emptyList_head_updated_Test()
        {
            Employee addedEmployee = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(addedEmployee);

            Assert.That(list.GetFirst(), Is.EqualTo(addedEmployee));
        }

        /// <summary>
        /// Test AddLast() to ensure it can handle null being added to list.
        /// </summary>
        [Test]
        public void AddLast_Null_element_is_allowed_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(null);

            Assert.That(list.Size, Is.EqualTo(1));
            Assert.That(list.GetFirst(), Is.Null);
            Assert.That(list.GetLast(), Is.Null);
        }


        /// <summary>
        /// Test AddLast() method to ensure the head pointer is updated when many objects are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_larger_Existing_list_Head_tail_and_size_Updated_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Head, Is.EqualTo(null));

            list.AddLast(employee1);
            Node<Employee> first = list.Tail;

            list.AddLast(employee2);
            Node<Employee> second = list.Tail;

            list.AddLast(employee3);
            Node<Employee> third = list.Tail;

            Assert.That(list.Head.Element, Is.EqualTo(employee1)); // 1 , 2, 3, head should be 1
            Assert.That(list.Tail.Element, Is.EqualTo(employee3)); // 1 , 2, 3, tail should be 3

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        #endregion

        #endregion

        #region Milestone 2


        #region RemoveFirst()
        /// <summary>
        /// Test calling RemoveFirst() on an empty list causes an exception.
        /// </summary>
        [Test]
        public void RemoveFirst_on_EmptyList_throws_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.RemoveFirst(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test RemoveFirst() returns reduced count by 1
        /// </summary>
        [Test]
        public void RemoveFirst_decreases_count_by_1_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);
            Assert.That(list.Size, Is.EqualTo(1));
            list.RemoveFirst();
            Assert.That(list.Size, Is.EqualTo(0));
        }

        /// <summary>
        /// Test RemoveFirst() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveFirst_Returns_first_Element_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);
            var firstElement = list.GetFirst();
            var returnedElement = list.RemoveFirst();

            Assert.That(returnedElement, Is.EqualTo(firstElement));
        }

        /// <summary>
        /// Test RemoveFirst() removes the head and tail on size 1 list
        /// </summary>
        [Test]
        public void RemoveFirst_on_list_of_size_1_removes_head_and_tail_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);
            list.RemoveFirst();

            Assert.That(list.IsEmpty(), Is.EqualTo(true));
            Assert.That(list.Head, Is.EqualTo(null));
            Assert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// RemoveFirst_on_larger_existingList_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_on_larger_existingList_updates_head_pointers_size_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.RemoveFirst();

            Assert.That(returnedElement, Is.EqualTo(employee1));

            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, second, third, list.Tail, list.Size));
        }

        #endregion

        #region RemoveLast()
        /// <summary>
        /// Test calling RemoveLast() on an empty list causes an exception.
        /// </summary>
        [Test]
        public void RemoveLast_on_EmptyList_throws_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.RemoveLast(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test RemoveLast() decreases count by 1.
        /// </summary>
        [Test]
        public void RemoveLast_decreases_count_by_1_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);
            Assert.That(list.Size, Is.EqualTo(1));
            list.RemoveLast();

            Assert.That(list.Size, Is.EqualTo(0));
        }

        /// <summary>
        /// Test RemoveLast() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveLast_Returns_last_Element_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);
            var lastElement = list.GetLast();
            var returnedElement = list.RemoveLast();

            Assert.That(returnedElement, Is.EqualTo(lastElement));
        }

        /// <summary>
        /// Test RemoveLast() removes head and tail on size 1 list
        /// </summary>
        [Test]
        public void RemoveLast_on_list_of_size_1_removes_head_and_tail_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);

            list.RemoveLast();

            Assert.That(list.IsEmpty(), Is.EqualTo(true));
            Assert.That(list.Head, Is.EqualTo(null));
            Assert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// RemoveLast_on_larger_existingList_updates_tail_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_on_larger_existingList_updates_tail_pointers_size_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.RemoveLast();

            Assert.That(returnedElement, Is.EqualTo(employee3));

            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, first, second, list.Tail, list.Size));
        }


        #endregion

        #region Get(position)

        /// <summary>
        /// Make sure that calling Get(position) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void Get_By_Position_On_EmptyList_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.Get(1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Make sure at calling Get(position) with a negative number results in an exception.
        /// </summary>
        [Test]
        public void Get_By_number_less_than_1_on_existingList_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            list.AddFirst(employee1);

            Assert.That(() => list.Get(-1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Get(positoin) with a value larger than the size of the list results in an exception.
        /// </summary>
        [Test]
        public void Get_By_Position_larger_than_list_size_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            list.AddFirst(employee1);

            Assert.That(() => list.Get(list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_1_on_existingList_returns_head_element_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);

            Assert.That(list.Get(1), Is.EqualTo(list.GetFirst()));
        }

        /// <summary>
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_2_on_list_of_size_2_returns_last_element_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            list.AddFirst(employee1);

            Assert.That(list.Get(2), Is.EqualTo(list.GetLast()));
        }


        /// <summary>
        /// Get_By_Position_2_on_list_of_size_3_returns_last_element_does_not_impact_tail_head_size_pointers_Test
        /// </summary>
        [Test]
        public void Get_By_Position_2_on_list_of_size_3_returns_last_element_does_not_impact_tail_head_size_pointers_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            Assert.That(list.Head.Element, Is.EqualTo(employee1)); // 1 , 2, 3, head should be 1
            Assert.That(list.Tail.Element, Is.EqualTo(employee3)); // 1 , 2, 3, tail should be 3

            Assert.That(list.Get(2), Is.EqualTo(second.Element));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        #endregion

        #region AddAfter(element, position)
        /// <summary>
        /// Ensure that calling AddAfter() on an empty list will result in an exception.
        /// </summary>
        [Test]
        public void AddAfterPosition_on_EmptyList_throws_exception_test()
        {
            Employee employee = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.AddAfter(employee, 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing a negative position value to AddAfter(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddAfterPosition_Negative_Position_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee addEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.AddAfter(addEmployee, -1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing a position value larger than size to AddAfter(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddAfterPosition_getsize_plus_1_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee addEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.AddAfter(addEmployee, list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }


        /// <summary>
        /// Checking edge case; Ensure that passing the size as the position will append to the end of the list without error.
        /// </summary>
        [Test]
        public void AddAfterPosition_using_GetSize_on_existingList_updates_tail_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            list.AddAfter(employee3, list.Size); // 1, 2, 3... should add to tail, after 2

            Node<Employee> third = list.Tail;

            Assert.That(list.Get(1), Is.EqualTo(employee1));
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.Get(3), Is.EqualTo(employee3));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        /// <summary>
        /// Make sure element is inserted into proper position.
        /// </summary>
        [Test]
        public void AddAfter_Position_1_on_existingList_inserts_after_head_pointers_updatedTest()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            list.AddAfter(employee2, 1); // 1, 2, 3 after this add
            Node<Employee> second = first.Next;

            Assert.That(list.Get(1), Is.EqualTo(employee1));
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.Get(3), Is.EqualTo(employee3));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        #endregion

        #region AddBefore(element, positon)
        /// <summary>
        /// Ensure that calling AddBefore() on an empty list will result in an exception.
        /// </summary>
        [Test]
        public void AddBeforePosition_on_EmptyList_throws_exception_test()
        {
            Employee employee = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.AddAfter(employee, 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing a negative position value to AddBefore(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddBeforePosition_Negative_Position_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee addEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.AddBefore(addEmployee, -1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing a position value larger than size to AddBefore(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddBeforePosition_getsize_plus_1_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee addEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.AddBefore(addEmployee, list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }



        /// <summary>
        /// add before anything else is an add between nodes
        /// </summary>
        [Test]
        public void AddBeforePosition_using_GetSize_on_existingList_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            list.AddBefore(employee2, list.Size); // 1, 2, 3... should add before 3

            Node<Employee> second = list.Tail.Previous;

            Assert.That(list.Get(1), Is.EqualTo(employee1));
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.Get(3), Is.EqualTo(employee3));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        /// <summary>
        /// Checking edge case; Ensure that passing position 1 will prepepend to the begining of the list without error.
        /// </summary>
        [Test]
        public void AddBefore_Position_1_on_existingList_updates_head_and_pointers_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddBefore(employee1, 1); // 1, 2, 3 after this add
            Node<Employee> first = list.Head;

            Assert.That(list.Get(1), Is.EqualTo(employee1));
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.Get(3), Is.EqualTo(employee3));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }
        #endregion

        #region Remove(position)
        /// <summary>
        /// Make sure that calling Remove(position) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_On_EmptyList_throw_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.Remove(1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Make sure at calling Remove(position) with a negative number results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_Negative_number_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            list.AddFirst(employee1);

            Assert.That(() => list.Remove(-1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Remove(position) with a value of zero results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_Zero_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            list.AddFirst(employee1);

            Assert.That(() => list.Remove(0), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Remove(position) with a value larger than the size of the list results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_getsize_plus_one_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            list.AddFirst(employee1);

            Assert.That(() => list.Remove(100), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that Remove() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveByPosition_Returns_an_Element_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);

            var returnedElement = list.Remove(1);

            Assert.That(returnedElement, Is.EqualTo(employee1));
        }

        /// <summary>
        /// Ensure that Remove() decreases count and clears the list
        /// </summary>
        [Test]
        public void RemoveByPosition_decreases_count_by_one_updates_head_tail_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);

            Assert.That(list.Size, Is.EqualTo(1));

            var returnedElement = list.Remove(1);

            Assert.That(list.Size, Is.EqualTo(0));
            Assert.That(list.Head, Is.Null);
            Assert.That(list.Tail, Is.Null);
        }


        /// <summary>
        /// RemoveByPosition_list_of_size_2_updates_tail_when_size_1_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_list_of_size_2_updates_tail_when_size_1_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            Node<Employee> last = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.Remove(list.Size); // removes employee 2

            Assert.That(returnedElement, Is.EqualTo(employee2));

            // check employee 1 is the only one left and is the head and tail, with a list size of 1
            Assert.True(CheckIntegrityBetweenListOfOneNode(list.Head, first, list.Tail, list.Size));
        }


        /// <summary>
        /// RemoveByPosition_last_position_on_list_of_size_3_updates_tail_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_last_position_on_list_of_size_3_updates_tail_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> last = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.Remove(list.Size); // removes employee 3

            Assert.That(returnedElement, Is.EqualTo(employee3));

            // check employee 1 is the head amd employee2 is the tail, with a list size of 2
            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, first, second, list.Tail, list.Size));
        }

        /// <summary>
        /// Ensure that Remove() removes the element at the correct position.
        /// </summary>
        [Test]
        public void RemoveByPosition_2_in_list_of_size_3_removes_the_right_node_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> last = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.Remove(2); // removes employee2

            Assert.That(returnedElement, Is.EqualTo(employee2));

            // check employee 1 is the head amd employee3 is the tail, with a list size of 2
            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, first, last, list.Tail, list.Size));
        }


        /// <summary>
        /// Test Remove(position) properly updated the head when removing from position 1.
        /// </summary>
        [Test]
        public void RemoveByPosition_Head_Updated_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> last = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.Remove(1); // removes employee 1

            Assert.That(returnedElement, Is.EqualTo(employee1));

            // check employee2 is the head amd employee3 is the tail, with a list size of 2
            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, second, last, list.Tail, list.Size));
        }

        #endregion

        #region Set(element, position)
        /// <summary>
        /// Test Set(position) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void SetByPosition_On_EmptyList_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.Set(employee1, 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Set(position) with a negative number results in an exception.
        /// </summary>
        [Test]
        public void SetByPosition_Negative_Value_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);

            Assert.That(() => list.Set(employee2, -1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Set(position) with a value of zero results in an exception.
        /// </summary>
        [Test]
        public void SetByPosition_Zero_throws_exception_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);

            Assert.That(() => list.Set(employee2, 0), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Set(position) with a value larger than the size of the list results in an exception.
        /// </summary>
        [Test]
        public void SetByPositionLargerThanSizeTest()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);

            Assert.That(() => list.Set(employee2, 100), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that Set(position) sets the element at the correct position.
        /// </summary>
        [Test]
        public void SetByPosition_1_on_list_of_1_updates_element_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            Assert.That(list.Get(1), Is.EqualTo(employee1));

            list.Set(employee2, 1);

            Assert.That(list.Get(1), Is.EqualTo(employee2));

            // check that pointers are still correct and head/tail has not changed:
            Assert.True(CheckIntegrityBetweenListOfOneNode(list.Head, first, list.Tail, list.Size));
        }

        /// <summary>
        /// Test Set(position) returns the replaced element.
        /// </summary>
        [Test]
        public void SetByPosition_Returns_old_Element_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);

            var returnedData = list.Set(employee2, 1);

            Assert.That(returnedData, Is.EqualTo(employee1));
        }

        /// <summary>
        /// Ensure that Set(position) sets the element at the correct position.
        /// </summary>
        [Test]
        public void SetByPosition_3_on_list_of_3_updates_element_Test()
        {

            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);
            Employee employee4 = new Employee(4);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> last = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.Set(employee4, list.Size); // replaces employee3 with employee4

            Assert.That(returnedElement, Is.EqualTo(employee3));

            // check employee 1 is the head amd employee4 is the tail, with a list size of 3
            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, last, list.Tail, list.Size));
        }
        #endregion
        #endregion


        #region Milestone 3

        #region Get(element)


        /// <summary>
        /// Make sure that Get(element) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void GetByElement_On_EmptyList_throw_exception_Test()
        {
            Employee employee = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.Get(employee), Throws.Exception.TypeOf<ApplicationException>());
        }

        ///// <summary>
        ///// Ensure that calling Get(element) with element that is not in the list results in an exception.
        ///// </summary>
        [Test]
        public void GetByElement_no_match_found_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee missingEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.Get(missingEmployee), Throws.Exception.TypeOf<ApplicationException>());
        }


        ///// <summary>
        ///// Ensure that Get by element returns the element at the correct element.
        ///// </summary>
        [Test]
        public void GetByElement_returns_the_element_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            list.AddFirst(employee1);

            Assert.That(list.Get(employee1).CompareTo(employee1), Is.EqualTo(0));
            Assert.That(list.Get(employee2).CompareTo(employee2), Is.EqualTo(0));
        }

        ///// <summary>
        ///// Ensure that calling Get(element) with element that matches multiple list elements returns only one result.
        ///// </summary>
        [Test]
        public void GetByElement_Multiple_matches_found_returns_first_match_test()
        {
            Employee employee = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(employee);
            list.AddLast(employee2);
            list.AddLast(employee);

            Assert.That(list.Get(employee).CompareTo(employee), Is.EqualTo(0));
        }
        //#endregion

        //#region AddAfter(element, oldElement)
        ///// <summary>
        ///// Ensure that calling AddAfter(element) on an empty list will result in an exception.
        ///// </summary>
        [Test]
        public void AddAfterByElement_on_EmptyList_throws_exception_test()
        {
            Employee employee = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();
            Assert.That(() => list.AddAfter(employee, employee), Throws.Exception.TypeOf<ApplicationException>());
        }

        ///// <summary>
        ///// Ensure that passing element that is not in the list to AddAfter(element) results in an exception.
        ///// </summary>
        [Test]
        public void AddAfterByElement_no_match_found_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee addEmployee = new Employee(2);
            Employee nonListEmployee = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.AddAfter(addEmployee, nonListEmployee), Throws.Exception.TypeOf<ApplicationException>());
        }

        ///// <summary>
        ///// Ensure that passing null value to AddAfter(element, position) results in an exception.
        ///// </summary>
        [Test]
        public void AddAfterByElement_when_element_is_null_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee addEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.AddAfter(addEmployee, null), Throws.Exception.TypeOf<ArgumentNullException>());
        }


        /// <summary>
        /// Checking edge case; Ensure that passing the tail element will append to the end of the list without error.
        /// </summary>
        [Test]
        public void AddAfterByElement_using_last_element_on_existingList_updates_tail_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            list.AddAfter(employee3, list.Tail.Element); // 1, 2, 3... should add to tail, after 2

            Node<Employee> third = list.Tail;

            Assert.That(list.Get(1), Is.EqualTo(employee1));
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.Get(3), Is.EqualTo(employee3));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        /// <summary>
        /// Make sure element is inserted into proper position.
        /// </summary>
        [Test]
        public void AddAfterByElement_using_head_element_on_existing_list_inserts_between_nodes_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            list.AddAfter(employee2, list.Head.Element); // 1, 2, 3, will add 2 after 1

            Node<Employee> second = list.Head.Next;

            Assert.That(list.Get(1), Is.EqualTo(employee1));
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.Get(3), Is.EqualTo(employee3));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));

        }
        /// <summary>
        /// Ensure that passing a element that appears multiple times in the list to AddAfter(element, oldElement) element is inserted after first instance.
        /// </summary>
        [Test]
        public void AddAfterByElement_multiple_match_found_adds_after_first_instance_Test()
        {
            Employee employee = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee addEmployee = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);
            Node<Employee> fourth = list.Head;

            list.AddFirst(employee2);
            Node<Employee> third = list.Head;

            list.AddFirst(employee); // order will be: 1, 2, 1
            Node<Employee> first = list.Head;

            list.AddAfter(addEmployee, employee); // order should be: 1, 3, 2, 1
            Node<Employee> second = list.Head.Next;

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));
            Assert.That(list.Get(4), Is.EqualTo(fourth.Element));

            Assert.True(CheckIntegrityBetweenListOfFourNodes(list.Head, first, second, third, fourth, list.Tail, list.Size));
        }
        //#endregion

        //#region AddBefore(element, oldElement)
        /// <summary>
        /// Ensure that calling AddBefore(element) on an empty list will result in an exception.
        /// </summary>
        [Test]
        public void AddBeforeByElement_on_EmptyList_throws_exception_test()
        {
            Employee employee = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();
            Assert.That(() => list.AddBefore(employee, employee), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing element that is not in the list to AddBefore(element) results in an exception.
        /// </summary>
        [Test]
        public void AddBeforeByElement_no_match_found_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee addEmployee = new Employee(2);
            Employee nonListEmployee = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.AddBefore(addEmployee, nonListEmployee), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing null value to AddBefore(element, position) results in an exception.
        /// </summary>
        [Test]
        public void AddBeforeByElement_when_element_is_null_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee addEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.AddBefore(addEmployee, null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Checking edge case; Ensure that passing the head element will prepend to the beginning of the list without error.
        /// </summary>
        [Test]
        public void AddBeforeByElement_using_head_element_on_existingList_updates_head_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee1);
            Node<Employee> second = list.Head;

            list.AddBefore(employee3, list.Head.Element); // 1, 2, 3... should add to head, before 2

            Node<Employee> first = list.Head;

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        /// <summary>
        /// Make sure element is inserted into proper position.
        /// </summary>
        [Test]
        public void AddBeforeByElement_using_tail_element_on_existing_list_inserts_between_nodes_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddBefore(employee1, list.Head.Element); // 1, 2, 3, will add 1 before 2

            Node<Employee> first = list.Head;

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));

            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));

        }
        /// <summary>
        /// Ensure that passing a element that appears multiple times in the list to AddBefore(element, oldElement) element is before the first instance.
        /// </summary>
        [Test]
        public void AddBeforeByElement_multiple_match_found_adds_before_first_instance_Test()
        {
            Employee employee = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee addEmployee = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);
            Node<Employee> fourth = list.Head;

            list.AddFirst(employee2);
            Node<Employee> third = list.Head;

            list.AddFirst(employee); // order will be: 1, 2, 1
            Node<Employee> second = list.Head;

            list.AddBefore(addEmployee, employee); // order should be: 3, 1, 2, 1
            Node<Employee> first = list.Head;

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));
            Assert.That(list.Get(4), Is.EqualTo(fourth.Element));

            Assert.True(CheckIntegrityBetweenListOfFourNodes(list.Head, first, second, third, fourth, list.Tail, list.Size));
        }
        //#endregion

        //#region Remove(element)
        /// <summary>
        /// Make sure that calling Remove(element) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void RemoveByElement_On_EmptyList_throws_exception_Test()
        {
            Employee employee = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.Remove(employee), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Remove(element) with element that is not in the list results in an exception.
        /// </summary>
        [Test]
        public void RemoveByElement_Not_In_List_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee missingEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.Remove(missingEmployee), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test Remove(element) on list of one, removes the first node, reduces size and adjusts head/tail.
        /// </summary>
        [Test]
        public void RemoveByElement_on_list_of_1_decreases_size_sets_nulls_head_and_tail_Test()
        {
            Employee employee1 = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee1);
            list.Remove(employee1);
            Assert.That(list.Size, Is.EqualTo(0));
            Assert.That(list.Head, Is.Null);
            Assert.That(list.Tail, Is.Null);
        }


        /// <summary>
        /// RemoveByElementn_list_of_size_2_updates_tail_when_size_1_Test
        /// </summary>
        [Test]
        public void RemoveByElement_list_of_size_2_updates_tail_when_size_1_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.Remove(list.Tail.Element); // removes employee 2

            Assert.That(returnedElement, Is.EqualTo(employee2));

            Assert.That(list.Get(1), Is.EqualTo(first.Element));

            // check employee 1 is the only one left and is the head and tail, with a list size of 1
            Assert.True(CheckIntegrityBetweenListOfOneNode(list.Head, first, list.Tail, list.Size));
        }


        /// <summary>
        /// RemoveByPosition_last_position_on_list_of_size_3_updates_tail_Test
        /// </summary>
        [Test]
        public void RemoveByElement_tail_on_list_of_size_3_updates_tail_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> last = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.Remove(list.Tail.Element); // removes employee 3

            Assert.That(returnedElement, Is.EqualTo(employee3));

            // check employee 1 is the head amd employee2 is the tail, with a list size of 2
            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, first, second, list.Tail, list.Size));
        }

        /// <summary>
        /// Ensure that Remove() removes the element at the correct position.
        /// </summary>
        [Test]
        public void RemoveByElement_middle_in_list_of_size_3_updates_pointers_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> last = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head; // order: 1, 2, 3

            var returnedElement = list.Remove(list.Get(2)); // removes employee2

            Assert.That(returnedElement, Is.EqualTo(employee2));

            // check employee1 is the head amd employee3 is the tail, with a list size of 2
            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, first, last, list.Tail, list.Size));
        }


        /// <summary>
        /// Test Remove(Element) properly updated the head when removing from head
        /// </summary>
        [Test]
        public void RemoveByElement_Head_Updated_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> last = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head; //order: 1,2,3

            var returnedElement = list.Remove(list.Head.Element); // removes employee 1

            Assert.That(returnedElement, Is.EqualTo(employee1));

            // check employee2 is the head amd employee3 is the tail, with a list size of 2
            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, second, last, list.Tail, list.Size));
        }

        /// <summary>
        /// Ensure that calling Remove(element) with element that matches multiple list elements returns only one result.
        /// </summary>
        [Test]
        public void RemoveByElement_multiple_matches_removes_first_match_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);
            Node<Employee> last = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;  // order is: 1, 2, 1

            var returnedElement = list.Remove(employee1); // removes first employee 1

            Assert.That(returnedElement, Is.EqualTo(employee1));

            // check employee2 is the head amd employee1 is the tail, with a list size of 2
            Assert.True(CheckIntegrityBetweenListOfTwoNodes(list.Head, second, last, list.Tail, list.Size));
        }
        //#endregion

        //#region Set(element, oldElement)
        /// <summary>
        /// Ensure that calling Set(element, oldElement) on an empty list will result in an exception.
        /// </summary>
        [Test]
        public void SetByElement_on_EmptyList_throws_Exception_test()
        {
            Employee employee = new Employee(1);

            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(() => list.Set(employee, employee), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing element that is not in the list to Set(element, oldElement) results in an exception.
        /// </summary>
        [Test]
        public void SetByElement_no_match_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee updatedEmployee = new Employee(2);
            Employee nonListEmployee = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.Set(updatedEmployee, nonListEmployee), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that passing null value to Set(element, oldElement) results in an exception.
        /// </summary>
        [Test]
        public void SetByElement_Null_element_throws_exception_Test()
        {
            Employee employee = new Employee(1);
            Employee updatedEmployee = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(employee);

            Assert.That(() => list.Set(updatedEmployee, null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test Set(element, oldElement) updates first element on list of one.
        /// </summary>
        [Test]
        public void SetByElement_updates_element_returns_old_value_maintains_pointers_change_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;

            var returnedElement = list.Set(employee2, employee1); // set first to employee 2

            Assert.That(returnedElement, Is.EqualTo(employee1));

            Assert.That(list.Get(1), Is.EqualTo(first.Element));

            // check employee2 is the head amd employee2 is the tail, with a list size of 1
            Assert.True(CheckIntegrityBetweenListOfOneNode(list.Head, first, list.Tail, list.Size));
        }

        /// <summary>
        /// Ensure that passing a element that appears multiple times in the list to Set(element, oldElement) only first instance is replaced.
        /// </summary>
        [Test]
        public void SetByElement_Multiple_Matching_changes_first_instance_only_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;  // order is: 1, 2, 1

            var returnedElement = list.Set(employee3, employee1); // sets head to employee3

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));

            Assert.That(returnedElement, Is.EqualTo(employee1));

            // check employee3 is the head amd employee1 is the tail, with a list size of 2
            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }
        //#endregion


        //#region Insert()
        /// <summary>
        /// Test that Insert() can insert into an empty list and update the head/tail
        /// </summary>
        [Test]
        public void Insert_EmptyList_increases_size_updates_head_and_tail_Test()
        {
            Employee employee1 = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();

            Assert.That(list.Size, Is.EqualTo(0));

            list.Insert(employee1);
            Node<Employee> first = list.Head;  // order is: 1

            Assert.That(list.Get(1), Is.EqualTo(first.Element));

            // check employee1 is the head amd employee1 is the tail, with a list size of 1
            Assert.True(CheckIntegrityBetweenListOfOneNode(list.Head, first, list.Tail, list.Size));
        }

        /// <summary>
        /// Test that Insert() adds an element to the list in ascending order spot
        /// </summary>
        [Test]
        public void Insert_Adds_inbetween_head_and_tail_when_value_between_Test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;  // order is: 1, 3

            list.Insert(employee2);
            Node<Employee> second = list.Head.Next;  // order is: 1,2,3

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));

            // check employee3 is the head amd employee1 is the tail, with a list size of 3
            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        /// <summary>
        /// Edge case; check that Insert() will insert into the head position without error.
        /// </summary>
        [Test]
        public void Insert_at_Head_Position_when_smallest_list_value_Test()
        {

            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;  // order is: 2, 3

            list.Insert(employee1);
            Node<Employee> first = list.Head;  // order is: 1,2,3

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));

            // check employee1 is the head amd employee3 is the tail, with a list size of 3
            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        /// <summary>
        /// Edge case; check that Insert() will insert into the tail position without error.
        /// </summary>
        [Test]
        public void InsertTailPositionTest()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee2);
            Node<Employee> second = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;   // order is: 1, 2

            list.Insert(employee3);
            Node<Employee> third = list.Tail;// order is: 1,2,3

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));

            // check employee1 is the head amd employee3 is the tail, with a list size of 3
            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        /// <summary>
        /// Test that Insert() can handle inserting when duplicates exist in the list already.
        /// </summary>
        [Test]
        public void Insert_duplicate_values_in_list_still_maintain_order_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> fourth = list.Head;

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;   // order is: 1, 3, 3

            list.Insert(employee2);
            Node<Employee> second = list.Head.Next;   // order is: 1, 2, 3, 3

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));
            Assert.That(list.Get(4), Is.EqualTo(fourth.Element));

            // check employee1 is the head amd employee3 is the tail, with a list size of 4
            Assert.True(CheckIntegrityBetweenListOfFourNodes(list.Head, first, second, third, fourth, list.Tail, list.Size));
        }

        /// <summary>
        /// Test that Insert() can handle inserting when value to add exists in the list already.
        /// </summary>
        [Test]
        public void Insert_new_value_exists_in_list_adds_in_order_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee3);
            Node<Employee> fourth = list.Head;

            list.AddFirst(employee2);
            Node<Employee> third = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;   // order is: 1, 2, 3

            list.Insert(employee2);
            Node<Employee> second = list.Head.Next;   // order is: 1, 2, 2, 3,

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));
            Assert.That(list.Get(4), Is.EqualTo(fourth.Element));

            // check employee1 is the head amd employee3 is the tail, with a list size of 4
            Assert.True(CheckIntegrityBetweenListOfFourNodes(list.Head, first, second, third, fourth, list.Tail, list.Size));
        }

        /// <summary>
        ///Test that Insert() can handle inserting when list is not ordered
        /// </summary>
        [Test]
        public void Insert_new_value_in_non_ordered_list_assigns_in_natural_order_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);
            Node<Employee> fourth = list.Head;

            list.AddFirst(employee3);
            Node<Employee> third = list.Head;

            list.AddFirst(employee1);
            Node<Employee> first = list.Head;   // order is: 1, 3, 1

            list.Insert(employee2);
            Node<Employee> second = list.Head.Next;   // order is: 1, 2, 3, 1

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));
            Assert.That(list.Get(4), Is.EqualTo(fourth.Element));

            // check employee1 is the head amd employee1 is the tail, with a list size of 4
            Assert.True(CheckIntegrityBetweenListOfFourNodes(list.Head, first, second, third, fourth, list.Tail, list.Size));
        }

        /// <summary>
        ///Test that Insert() can handle inserting when list is not ordered, largest number is first
        /// </summary>
        [Test]
        public void Insert_new_value_in_non_ordered_list_assigns_in_natural_order_largest_number_is_first_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);
            Node<Employee> third = list.Head;

            list.AddFirst(employee3);
            Node<Employee> second = list.Head;   // order is: 3, 1

            list.Insert(employee2);
            Node<Employee> first = list.Head;   // order is: 2, 3, 1

            Assert.That(list.Get(1), Is.EqualTo(first.Element));
            Assert.That(list.Get(2), Is.EqualTo(second.Element));
            Assert.That(list.Get(3), Is.EqualTo(third.Element));

            // check employee1 is the head amd employee1 is the tail, with a list size of 4
            Assert.True(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }
        //#endregion


        //#region SortAscending()
        /// <summary>
        /// We run SortAscending() on an empty list, no exceptions should be thrown.
        /// </summary>
        [Test]
        public void SortAscending_on_EmptyList_does_not_throw_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.SortAscending();
            Assert.That(list.IsEmpty());
            Assert.That(list.Head, Is.Null);
            Assert.That(list.Tail, Is.Null);
        }

        /// <summary>
        /// We run SortAscending() on a list of 1, no changes should be made.
        /// </summary>
        [Test]
        public void SortAscending_on_list_of_1_does_not_change_anything_test()
        {
            Employee employee1 = new Employee(1);
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.Insert(employee1);
            list.SortAscending();
            Assert.That(list.GetFirst(), Is.EqualTo(employee1));

            Node<Employee> first = list.Head;
            Assert.That(CheckIntegrityBetweenListOfOneNode(list.Head, first, list.Tail, list.Size));
        }

        /// <summary>
        /// We run SortAscending() on a sorted list of 2, no changes should be made.
        /// </summary>
        [Test]
        public void SortAscending_on_sorted_list_of_2_does_not_change_anything_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.Insert(employee1);
            list.Insert(employee2);
            list.SortAscending();

            Assert.That(list.GetFirst(), Is.EqualTo(employee1));
            Assert.That(list.GetLast(), Is.EqualTo(employee2));

            Node<Employee> first = list.Head;
            Node<Employee> second = list.Head.Next;

            Assert.That(CheckIntegrityBetweenListOfTwoNodes(list.Head, first, second, list.Tail, list.Size));
        }

        /// <summary>
        /// We run SortAscending() on a sorted list of 3, no changes should be made.
        /// </summary>
        [Test]
        public void SortAscending_on_sorted_list_of_3_does_not_change_anything_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.Insert(employee1);
            list.Insert(employee2);
            list.Insert(employee3);

            list.SortAscending();

            Assert.That(list.GetFirst(), Is.EqualTo(employee1));
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.GetLast(), Is.EqualTo(employee3));

            Node<Employee> first = list.Head;
            Node<Employee> second = list.Head.Next;
            Node<Employee> third = list.Tail;

            Assert.That(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));
        }

        /// <summary>
        /// We run SortAscending() on an unsorted list of 2, should sort the values
        /// </summary>
        [Test]
        public void SortAscending_on_unsorted_list_of_2_sorts_ascending_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddLast(employee1);
            list.AddFirst(employee2);

            list.SortAscending();

            Assert.That(list.GetFirst(), Is.EqualTo(employee1));
            Assert.That(list.GetLast(), Is.EqualTo(employee2));

            Node<Employee> first = list.Head;
            Node<Employee> second = list.Head.Next;

            Assert.That(CheckIntegrityBetweenListOfTwoNodes(list.Head, first, second, list.Tail, list.Size));
        }

        /// <summary>
        /// We run SortAscending() on an unsorted list of 3, should sort the values
        /// </summary>
        [Test]
        public void SortAscending_on_Unsorted_list_of_3_sorts_ascending_test()
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddLast(employee1);
            list.AddFirst(employee3);
            list.AddFirst(employee2);
            list.SortAscending();

            Assert.That(list.GetFirst(), Is.EqualTo(employee1));
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.GetLast(), Is.EqualTo(employee3));

            Node<Employee> first = list.Head;
            Node<Employee> second = list.Head.Next;
            Node<Employee> third = list.Tail;

            Assert.That(CheckIntegrityBetweenListOfThreeNodes(list.Head, first, second, third, list.Tail, list.Size));

        }

        /// <summary>
        /// We run SortAscending() on a large unsorted list with duplicates, should sort the values
        /// </summary>
        [Test]
        public void SortAscending_on_large_Unsorted_list_with_duplicates_sorts_ascending_test()
        {

            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddLast(employee1);
            list.AddFirst(employee3);
            list.AddFirst(employee2);
            list.AddFirst(employee3);// order was: 3, 2, 3, 1

            list.SortAscending();

            Node<Employee> first = list.Head;
            Node<Employee> second = list.Head.Next;
            Node<Employee> third = list.Tail.Previous;
            Node<Employee> fourth = list.Tail;

            Assert.That(list.GetFirst(), Is.EqualTo(employee1)); // 1, 2, 3, 3
            Assert.That(list.Get(2), Is.EqualTo(employee2));
            Assert.That(list.Get(3), Is.EqualTo(employee3));
            Assert.That(list.GetLast(), Is.EqualTo(employee3));

            Assert.That(CheckIntegrityBetweenListOfFourNodes(list.Head, first, second, third, fourth, list.Tail, list.Size));

        }
        #endregion

        #endregion


        /* HELPER METHODS */
        private bool CheckIntegrityBetweenListOfOneNode(Node<Employee> head, Node<Employee> node1, Node<Employee> tail, int size)
        {
            return head == node1 && node1.Previous == null && node1.Next == null && tail == node1 && size == 1;
        }

        private bool CheckIntegrityBetweenListOfTwoNodes(Node<Employee> head, Node<Employee> node1, Node<Employee> node2, Node<Employee> tail, int size)
        {
            return head == node1 && node1.Previous == null && node1.Next == node2 &&
                    node2.Previous == node1 && node2.Next == null && tail == node2 && size == 2;
        }

        private bool CheckIntegrityBetweenListOfThreeNodes(Node<Employee> head, Node<Employee> node1, Node<Employee> node2, Node<Employee> node3, Node<Employee> tail, int size)
        {
            return head == node1 && node1.Previous == null && node1.Next == node2 &&
                    node2.Previous == node1 && node2.Next == node3 &&
                    node3.Previous == node2 && node3.Next == null && tail == node3 && size == 3;
        }

        private bool CheckIntegrityBetweenListOfFourNodes(Node<Employee> head, Node<Employee> node1, Node<Employee> node2, Node<Employee> node3, Node<Employee> node4, Node<Employee> tail, int size)
        {
            return head == node1 && node1.Previous == null && node1.Next == node2 &&
                    node2.Previous == node1 && node2.Next == node3 &&
                    node3.Previous == node2 && node3.Next == node4 &&
                    node4.Previous == node3 && node4.Next == null && tail == node4 && size == 4;
        }
    }
}