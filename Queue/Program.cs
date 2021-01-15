using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            String simpleWithoutExit = AppDomain.CurrentDomain.BaseDirectory + "simpleWithoutExit.maze";
            String simpleWithExit = AppDomain.CurrentDomain.BaseDirectory + "simpleWithExit.maze";

            //Maze maze = new Maze(simpleWithoutExit);
            Maze maze = new Maze(simpleWithExit);


            Console.WriteLine("{0}", maze.PrintMaze());
            Console.WriteLine("###########################################");
            Console.WriteLine("{0}", maze.BreadthFirstSearch());


            Console.ReadKey();
        }
    }
}
