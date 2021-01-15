using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee(1);
            Employee employee2 = new Employee(2);
            Employee employee3 = new Employee(3);


            Employee e = new Employee(2);

            LinkedList<Employee> list = new LinkedList<Employee>();

            list.AddFirst(employee1);
            Node<Employee> fourth = list.Head;

            list.AddFirst(employee2);
            Node<Employee> third = list.Head;

            list.AddFirst(employee3);
            Node<Employee> first = list.Head;   // order is: 1, 3, 1

            Node<Employee> tempNode = new Node<Employee>(e);

            //for (int i = 0; i < list.Size; i++)
                Console.WriteLine("{0}", list.GetPositionOfNode(tempNode));

            Console.ReadKey();

        }
    }
}
