using NUnit.Framework;
using System;
using Assignment1;

namespace TestLibrary
{
    /// <summary>
    /// IMPORTANT NOTE: DO NOT CHANGE THE TEST CODE!! EVER. :)
    /// EmployeeTest - A class for testing the Employee class
    /// Employee - A class for representing an employee with a first name, last name and EmployeeID.
    ///            Must be comparable with itself based on the EmployeeID
    /// 
    /// Assignment:     #1
    /// Course:         ADEV-3001
    /// Date Created:   August. 31, 2019
    /// 
    /// @author: Scott Wachal
    /// @version 1.0
    /// </summary>
    [TestFixture]
    public class EmployeesTest
    {

        #region Constructor Test
        /// <summary>
        /// Test the constructor that takes an EmployeeID number to make sure EmployeeID is set, and the other values are default.
        /// </summary>
        [Test]
        public void EmployeeId_Constructor_Test()
        {
            int employeeId = 32;
            Employee employee = new Employee(employeeId);

            Assert.That(employee, Is.Not.Null);
            Assert.That(employee.EmployeeID, Is.EqualTo(employeeId));
            Assert.That(employee.FirstName, Is.EqualTo(null));
            Assert.That(employee.LastName, Is.EqualTo(null));

        }

        /// <summary>
        /// Test the constructor that takes all parameters to ensure the values are being set correctly.
        /// Because the properties are read-only, this test is implictly testing our getter methods as well.
        /// </summary>
        [Test]
        public void FullEmployee_Constructor_Test()
        {
            int employeeId = 32;
            string firstName = "John";
            string lastName = "Smith";

            Employee employee = new Employee(employeeId, firstName, lastName);

            Assert.That(employee, Is.Not.Null);
            Assert.That(employee.EmployeeID, Is.EqualTo(employeeId));
            Assert.That(employee.FirstName, Is.EqualTo(firstName));
            Assert.That(employee.LastName, Is.EqualTo(lastName));

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Test the CompareTo with an object that should preceed the second object.
        /// </summary>
        [Test]
        public void CompareTo_First_is_Lower_Test()
        {
            IComparable<Employee> employee1 = new Employee(1, "First", "Employee");
            Employee employee2 = new Employee(2, "Second", "Employee");

            Assert.That(employee1.CompareTo(employee2), Is.LessThan(0));

        }

        /// <summary>
        /// Test the CompareTo with an object that should follow the second object.
        /// </summary>
        [Test]
        public void CompareTo_First_is_Higher_Test()
        {
            IComparable<Employee> employee1 = new Employee(2, "First", "Employee");
            Employee employee2 = new Employee(1, "Second", "Employee");

            Assert.That(employee1.CompareTo(employee2) > 0);

        }

        /// <summary>
        /// Test the CompareTo with two objects that are equal.
        /// </summary>
        [Test]
        public void CompareTo_Equal_Test()
        {
            IComparable<Employee> e1 = new Employee(1, "First", "Employee");
            Employee e2 = new Employee(1, "Second", "Employee");

            Assert.That(e1.CompareTo(e2) == 0);
        }

        /// <summary>
        /// Test the ToString method with a FirstName and LastName set to ensure the returned string is as expected.
        /// </summary>
        [Test]
        public void ToString_Test()
        {
            int employeeId = 1;
            string firstName = "First";
            string lastName = "Employee";
            Employee employee = new Employee(employeeId, firstName, lastName);

            string expectedToString = $"{employeeId} {firstName} {lastName}";
            Assert.That(employee.ToString(), Is.EqualTo(expectedToString));
        }

        /// <summary>
        /// Test the ToString method without a FirstName or LastName set, should display with the word null for the missing values
        /// </summary>
        [Test]
        public void ToString_with_no_names_shows_Nulls_Test()
        {
            int employeeId = 1;
            Employee employee = new Employee(employeeId);

            string expectedToString = $"{employeeId} null null";
            Assert.That(employee.ToString(), Is.EqualTo(expectedToString));
        }
        #endregion
    }
}