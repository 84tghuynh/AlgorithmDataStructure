using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Assignment2;

namespace Assignment2
{
    public class Maze
    {
        public Point StartingPoint { get; set; }
        public int RowLength { get; set; }
        public int ColumnLength { get; set; }
        public char[][] charMaze;
        public Stack<Point> FoundStackPath = null;

        /// <summary>
        /// Returns the charMaze array
        /// </summary>
        /// <returns></returns>
        public char[][] GetMaze() { return charMaze; }
        /// <summary>
        /// Constructor reads a specified file while populating maze details.
        /// </summary>
        /// <param name="fileNameOfMaze"></param>
        public Maze(String fileNameOfMaze)
        {
                String line;
                String[] firstLine;
                String[] secondLine;
                int i;
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileNameOfMaze);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                i = 1;
                
                while (line != null) { 
                    if (i == 1){

                        firstLine = line.Trim().Split(' ');

                        this.RowLength = Int32.Parse(firstLine[0]);
                        this.ColumnLength = Int32.Parse(firstLine[1]);

                        this.charMaze = new Char[this.RowLength][];

                    }
                    else if (i == 2)
                    {
                        secondLine = line.Trim().Split(' ');
                        this.StartingPoint = new Point(int.Parse(secondLine[0]), int.Parse(secondLine[1]));

                    }
                    else
                    {
                        this.charMaze[i-3] = line.ToCharArray();
                    }

                    //Read the next line
                    line = sr.ReadLine();
                    i++;
                }
                //close the file
                sr.Close();

        }

        /// <summary>
        /// Constructor, assigns the starting point based on the passed Row/Column values.  
        /// Assigns internal charMaze variable to the passed existingMaze value.
        /// </summary>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="existingMaze"></param>

        public Maze(int startingRow, int startingColumn, char[][]existingMaze)
        {

            if(existingMaze[startingRow][startingColumn] == 'E' ||
               existingMaze[startingRow][startingColumn] == 'W' ||
               startingRow < 0                                  ||
               startingColumn <0                                ||
               startingRow >= existingMaze.Length                ||
               startingColumn >= existingMaze[0].Length
               )
            {
                throw new System.ApplicationException();
            }
            this.StartingPoint = new Point(startingRow, startingColumn);
            this.charMaze = existingMaze;
            this.RowLength = charMaze.Length;
            this.ColumnLength = charMaze[0].Length;
        }

        /// <summary>
        /// Print the maze from the charArray private variable. 
        /// It should look identical to the file (except missing the rows/columns counts and starting row/column)
        /// </summary>
        /// <returns></returns>
        public String PrintMaze()
        {
            String resultStringMaze = "";
            for(int i=0; i < charMaze.Length-1; i++)
            {
                resultStringMaze +=  new String(charMaze[i]) + '\n';
            }

            return resultStringMaze + new String(charMaze[charMaze.Length - 1]);
        }

        /// <summary>
        /// •	Performs a depth first search using the starting point values obtained in the constructor.
        /// •	Note: the path to follow will be visually indicated by changing your ‘V’s to ‘.’s for all nodes in your Stack.
        /// •	The returned value of this method will be a string indicating the path to follow 
        ///     and a print out of the maze after exploring (see details in the below pages for formatting)
        /// </summary>
        /// <returns></returns>

        public String DepthFirstSearch()
        {
            Stack<Point> stackPath = new Stack<Point>();

            Stack<Point> stackReversePath = new Stack<Point>();

            this.FoundStackPath = new Stack<Point>();

            stackPath.Push(this.StartingPoint);
            RecursiveDepthFirstSearch(stackPath.Top(), stackPath);

            String path = "";
            String stringPath = "";

            if (!stackPath.IsEmpty())
            {

                stringPath = "Path to follow from Start " + this.StartingPoint.ToString() +
                             " to Exit " + stackPath.Top().ToString() +
                             " - " + stackPath.Size.ToString() + " steps:\n";

                // Console.WriteLine("{0}", stringPath);

            }
            else
            {
                stringPath = "No exit found in maze!\n\n";
            }

            while (!stackPath.IsEmpty())
            {
                stackReversePath.Push(stackPath.Top());
                this.FoundStackPath.Push(stackPath.Top());

                if (this.charMaze[stackPath.Top().Row][stackPath.Top().Column] == 'V') this.charMaze[stackPath.Top().Row][stackPath.Top().Column] = '.';

                path += stackPath.Pop().ToString();
                //Console.WriteLine("{0}", path);
            }

            while (!stackReversePath.IsEmpty())
            {
                //stringPath += stackReversePath.Top().ToString() + "\n";
                //stackReversePath.Pop();

                stringPath += stackReversePath.Pop().ToString() + "\n";
            }



            return stringPath + this.PrintMaze();

        }

        /// <summary>
        /// Search recursively, based on the startingPoint (currentPoint)
        /// </summary>
        /// <param name="startingPoint"></param>
        /// <param name="stackPath"></param>
        /// <returns></returns>
        public Stack<Point> RecursiveDepthFirstSearch(Point startingPoint, Stack<Point> stackPath)
        {
            
            Point tmpPoint = startingPoint;

            if (this.charMaze[tmpPoint.Row][tmpPoint.Column] == 'E') return null;// stackPath;
            else if (this.charMaze[tmpPoint.Row][tmpPoint.Column] != 'V')
                this.charMaze[tmpPoint.Row][tmpPoint.Column] = 'V';

            switch(CheckCanMove(tmpPoint))
            {
                case 'S':
                    stackPath.Push(new Point(tmpPoint.Row + 1, tmpPoint.Column));
                    //Console.WriteLine("S:[{0}][{1}]", tmpPoint.Row + 1, tmpPoint.Column);
                    //Console.WriteLine("T-S:[{0}][{1}]", stackPath.Top().Row, stackPath.Top().Column);
                    RecursiveDepthFirstSearch(stackPath.Top(), stackPath);
                    break;
                case 'E':
                    stackPath.Push(new Point(tmpPoint.Row, tmpPoint.Column + 1));
                    //Console.WriteLine("E:[{0}][{1}]", tmpPoint.Row, tmpPoint.Column+1);
                    //Console.WriteLine("T-E:[{0}][{1}]", stackPath.Top().Row, stackPath.Top().Column);
                    RecursiveDepthFirstSearch(stackPath.Top(), stackPath);
                    break;
                case 'W':
                    stackPath.Push(new Point(tmpPoint.Row, tmpPoint.Column - 1));
                    //Console.WriteLine("W:[{0}][{1}]", tmpPoint.Row, tmpPoint.Column - 1);
                    //Console.WriteLine("T-W:[{0}][{1}]", stackPath.Top().Row, stackPath.Top().Column);
                    RecursiveDepthFirstSearch(stackPath.Top(), stackPath);
                    break;
                case 'N':
                    stackPath.Push(new Point(tmpPoint.Row - 1, tmpPoint.Column));
                    //Console.WriteLine("N:[{0}][{1}]", tmpPoint.Row-1, tmpPoint.Column);
                    //Console.WriteLine("T-N:[{0}][{1}]", stackPath.Top().Row, stackPath.Top().Column);
                    RecursiveDepthFirstSearch(stackPath.Top(), stackPath);
                    break;
                case 'Z': //Cannot move
                    stackPath.Pop();
                    if (stackPath.IsEmpty()) return null; //stackPath;
                    else
                        RecursiveDepthFirstSearch(stackPath.Top(), stackPath);
                    break;
            }


            return stackPath;
        }

        /// <summary>
        /// Check the Direction can move at the current point.
        /// Order check:  S,E,W,N  (South,East,West,North)
        /// </summary>
        /// <param name="tmpPoint"></param>
        /// <returns></returns>
        public char CheckCanMove(Point tmpPoint)
        {

            //South : Row +1 , Column
            if (this.charMaze[tmpPoint.Row + 1][tmpPoint.Column] == 'W' ||
               this.charMaze[tmpPoint.Row + 1][tmpPoint.Column] == 'V')
            {
                //East: Row, Column + 1
                if (this.charMaze[tmpPoint.Row][tmpPoint.Column + 1] == 'W' ||
                    this.charMaze[tmpPoint.Row][tmpPoint.Column + 1] == 'V')
                {
                    // West Row, Column - 1
                    if (this.charMaze[tmpPoint.Row][tmpPoint.Column - 1] == 'W' ||
                        this.charMaze[tmpPoint.Row][tmpPoint.Column - 1] == 'V')
                    {
                        // North Row-1, Column
                        if (this.charMaze[tmpPoint.Row-1][tmpPoint.Column] == 'W' ||
                            this.charMaze[tmpPoint.Row-1][tmpPoint.Column] == 'V')
                        {
                            return 'Z'; // Cannot move
                        }
                        else return 'N';
                    }
                    else return 'W';
                }
                else return 'E';
            }
            else return 'S';
        }
    
        /// <summary>
        /// •	Returns a stack containing the locations in the order of starting point to exit (top to bottom).
        /// •	It is required that DepthFirstSearch() runs before you can run this method.Otherwise, we would not have a populated stack.
        /// •	Note: you may want to clone or copy the stack before returning it. (some tests will try to ask for your stack twice, see tests for details)
        /// </summary>
        /// <returns></returns>
        public Stack<Point> GetPathToFollow()
        {
            if(this.FoundStackPath == null)
                throw new System.ApplicationException();

            Stack<Point> copyStackPath = new Stack<Point>();
            Stack<Point> reverseCopyPath = new Stack<Point>();
            if (!this.FoundStackPath.IsEmpty())
            {
                
                while (!this.FoundStackPath.IsEmpty())
                {

                    reverseCopyPath.Push(this.FoundStackPath.Top());
                    this.FoundStackPath.Pop();
                }


                while (!reverseCopyPath.IsEmpty())
                {

                    copyStackPath.Push(reverseCopyPath.Top());
                    this.FoundStackPath.Push(reverseCopyPath.Top());
                    reverseCopyPath.Pop();
                }


            }

            return copyStackPath;
        }



    }
}
