using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Must implement the Comparable interface. The comparison of employees is based on the EmployeeID.
    /// </summary>
    public class Employee : IComparable<Employee>
    {
        /// <summary>
        /// Once created, employee fields cannot be changed.
        /// </summary>
        public int EmployeeID { get;}

        public string FirstName { get;}
        public string LastName { get;}

        ///// <summary>
        ///// Constructor, initializes only the employeeID, but sets the other fields to null
        ///// Must contain an Employee ID number, an employee cannot be created without one
        ///// First and Last Name: Either both names will be provided or neither will be provided.
        ///// </summary>
        ///// <param name="employeeId"></param>
        //public Employee(int employeeId)
        //{
        //    this.EmployeeID = employeeId;
        //    this.FirstName = null;
        //    this.LastName = null;
        //}

        /// <summary>
        /// Constructor, initializes private fields using parameter values
        /// Must contain an Employee ID number, an employee cannot be created without one
        /// First and Last Name: Either both names will be provided or neither will be provided.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Employee(int employeeId, string firstName = null, string lastName = null)
        {
            this.EmployeeID = employeeId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Employees must be comparable with one another based on their EmployeeID value. 
        /// Larger values are bigger than smaller values.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Employee other)
        {
            return this.EmployeeID.CompareTo(other.EmployeeID);
        }

        /// <summary>
        /// Prints: employeeId firstName lastName
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string firstName = this.FirstName ?? "null";
            string lastName = this.LastName ?? "null";

            return $"{this.EmployeeID} {firstName} {lastName}";

        }


    }
}
