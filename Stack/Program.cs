using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
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
            Console.WriteLine("{0}",maze.DepthFirstSearch());



            Console.ReadKey();


        }
    }
}
