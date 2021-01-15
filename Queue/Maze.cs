using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Maze
    {

        public Point StartingPoint { get; set; }
        public int RowLength { get; set; }
        public int ColumnLength { get; set; }
        public char[][] charMaze;
        public Point[,] recordPath;
        public Stack<Point> FoundStackPath = null;

        /// <summary>
        /// Returns the charMaze array
        /// </summary>
        /// <returns></returns>
        public char[][] GetMaze()
        {
            return charMaze;
        }

        public Point[,] GetRecordPath()
        {
            return recordPath;
        }

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

            while (line != null)
            {
                if (i == 1)
                {

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
                    this.charMaze[i - 3] = line.ToCharArray();
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

        public Maze(int startingRow, int startingColumn, char[][] existingMaze)
        {

            if (existingMaze[startingRow][startingColumn] == 'E' ||
               existingMaze[startingRow][startingColumn] == 'W' ||
               startingRow < 0 ||
               startingColumn < 0 ||
               startingRow >= existingMaze.Length ||
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
            for (int i = 0; i < charMaze.Length - 1; i++)
            {
                resultStringMaze += new String(charMaze[i]) + '\n';
            }

            return resultStringMaze + new String(charMaze[charMaze.Length - 1]);
        }


        public String BreadthFirstSearch()
        {
            Queue<Point> queue = new Queue<Point>();

            Stack<Point> stackPath = new Stack<Point>();

            this.FoundStackPath = new Stack<Point>();

            if (this.charMaze[StartingPoint.Row][StartingPoint.Column] == 'E')
            {
                throw new System.ApplicationException();
            }

            this.charMaze[this.StartingPoint.Row][this.StartingPoint.Column] = 'V';
            queue.Enqueue(this.StartingPoint);

            this.recordPath = new Point[this.RowLength, this.ColumnLength];

            this.recordPath[this.StartingPoint.Row, this.StartingPoint.Column] = null;

            RecursiveBreadthFirstSearch(queue);


            String stringPath = "";

            if (!queue.IsEmpty())
            {
                Point exitPoint = queue.Tail.Element;

                Console.WriteLine("Creating StackPath===================");
                CreateStackPath(stackPath, exitPoint);

                Console.WriteLine("After Creating Stack: Stack Size {0}", stackPath.Size);


                stringPath = "Path to follow from Start " + this.StartingPoint.ToString() +
                            " to Exit " + exitPoint.ToString() +
                            " - " + stackPath.Size.ToString() + " steps:\n";

            }
            else
            {
                stringPath = "No exit found in maze!\n\n";
            }

            while (!stackPath.IsEmpty())
            {

                stringPath += stackPath.Pop().ToString() + "\n";
            }


            return stringPath + this.PrintMaze();
        }


        private void CreateStackPath(Stack<Point> stackPath, Point exitPoint)
        {
           
            stackPath.Push(exitPoint);
            this.FoundStackPath.Push(exitPoint);
            Point parentPoint = this.recordPath[exitPoint.Row,exitPoint.Column];
            int i = 1;
            Console.WriteLine("Exit {0} {1}", exitPoint.ToString(), i);

            while (parentPoint != null)
            {
                stackPath.Push(parentPoint);
                this.FoundStackPath.Push(parentPoint);

                if (this.charMaze[parentPoint.Row][parentPoint.Column] == 'V')
                    this.charMaze[parentPoint.Row][parentPoint.Column] = '.';
                i++;
                Console.WriteLine("i: {0}", i);
                parentPoint = this.recordPath[parentPoint.Row, parentPoint.Column];

                if (parentPoint != null)
                {
                   Console.WriteLine("Exit {0} {1} Stacksize {2}", parentPoint.ToString(), i, stackPath.Size);
                   
                }

            }

            Console.WriteLine("Finish recordPath: Stack Size {0}", stackPath.Size);
        }

        public Queue<Point> RecursiveBreadthFirstSearch(Queue<Point> queue)
        {
            if (queue.IsEmpty()) return queue;

            Point currentPoint = queue.Dequeue();

            //South  
            // Exit
            if (this.charMaze[currentPoint.Row + 1][currentPoint.Column] == 'E')
            {
                this.recordPath[currentPoint.Row + 1,currentPoint.Column] = currentPoint;
                Console.WriteLine("South exit [{0},{1}] {2}", currentPoint.Row + 1, currentPoint.Column, this.recordPath[currentPoint.Row + 1, currentPoint.Column].ToString());
                queue.Enqueue(new Point(currentPoint.Row + 1, currentPoint.Column));
                return queue;
            }

            // Visited
            //== V or W  ==> nothing to do
            //== ''      ==> Enqueue & Visited
            if ( this.charMaze[currentPoint.Row + 1][currentPoint.Column] != 'V' &&
                this.charMaze[currentPoint.Row + 1][currentPoint.Column] != 'W')
            {
                this.recordPath[currentPoint.Row + 1,currentPoint.Column] = currentPoint;
                Console.WriteLine("South visited [{0},{1}] {2}", currentPoint.Row + 1, currentPoint.Column, this.recordPath[currentPoint.Row + 1, currentPoint.Column].ToString());
                this.charMaze[currentPoint.Row + 1][currentPoint.Column] = 'V';
                queue.Enqueue(new Point(currentPoint.Row + 1, currentPoint.Column));
            }


            //East  
            // Exit
            if (this.charMaze[currentPoint.Row][currentPoint.Column + 1] == 'E')
            {
                this.recordPath[currentPoint.Row,currentPoint.Column + 1] = currentPoint;
                Console.WriteLine("East exit [{0},{1}] {2}", currentPoint.Row, currentPoint.Column + 1, this.recordPath[currentPoint.Row, currentPoint.Column +1].ToString());
                queue.Enqueue(new Point(currentPoint.Row, currentPoint.Column + 1));
                return queue;
            }

            // Visited
            //== V or W  ==> nothing to do
            //== ''      ==> Enqueue & Visited
            if (this.charMaze[currentPoint.Row][currentPoint.Column + 1] != 'V' &&
                this.charMaze[currentPoint.Row][currentPoint.Column + 1 ] != 'W')
            {
                this.recordPath[currentPoint.Row,currentPoint.Column + 1] = currentPoint;
                Console.WriteLine("East visited [{0},{1}] {2}", currentPoint.Row, currentPoint.Column + 1, this.recordPath[currentPoint.Row, currentPoint.Column + 1].ToString());
                this.charMaze[currentPoint.Row][currentPoint.Column + 1] = 'V';
                queue.Enqueue(new Point(currentPoint.Row, currentPoint.Column + 1));
            }

            //West 
            // Exit
            if (this.charMaze[currentPoint.Row][currentPoint.Column - 1] == 'E')
            {
                this.recordPath[currentPoint.Row,currentPoint.Column - 1] = currentPoint;
                Console.WriteLine("West exit [{0},{1}] {2}", currentPoint.Row, currentPoint.Column - 1, this.recordPath[currentPoint.Row, currentPoint.Column - 1].ToString());
                queue.Enqueue(new Point(currentPoint.Row, currentPoint.Column - 1));
                return queue;
            }

            // Visited
            //== V or W  ==> nothing to do
            //== ''      ==> Enqueue & Visited
            if (this.charMaze[currentPoint.Row][currentPoint.Column - 1] != 'V' &&
                this.charMaze[currentPoint.Row][currentPoint.Column - 1] != 'W')
            {
                this.recordPath[currentPoint.Row,currentPoint.Column - 1] = currentPoint;
                Console.WriteLine("West visited [{0},{1}] {2}", currentPoint.Row, currentPoint.Column - 1, this.recordPath[currentPoint.Row, currentPoint.Column - 1].ToString());
                this.charMaze[currentPoint.Row][currentPoint.Column - 1] = 'V';
                queue.Enqueue(new Point(currentPoint.Row, currentPoint.Column - 1));
            }


            //North  
            // Exit
            if (this.charMaze[currentPoint.Row - 1][currentPoint.Column] == 'E')
            {
                this.recordPath[currentPoint.Row - 1,currentPoint.Column] = currentPoint;
                Console.WriteLine("North exit [{0},{1}] {2}", currentPoint.Row - 1, currentPoint.Column, this.recordPath[currentPoint.Row - 1, currentPoint.Column].ToString());
                queue.Enqueue(new Point(currentPoint.Row - 1, currentPoint.Column));
                return queue;
            }
            // Visited
            //== V or W  ==> nothing to do
            //== ''      ==> Enqueue & Visited
            if (this.charMaze[currentPoint.Row - 1][currentPoint.Column] != 'V' &&

                this.charMaze[currentPoint.Row - 1][currentPoint.Column] != 'W')
            {
                this.recordPath[currentPoint.Row - 1,currentPoint.Column] = currentPoint;
                Console.WriteLine("North visited [{0},{1}] {2}", currentPoint.Row - 1, currentPoint.Column, this.recordPath[currentPoint.Row - 1, currentPoint.Column].ToString());
                this.charMaze[currentPoint.Row - 1][currentPoint.Column] = 'V';
                queue.Enqueue(new Point(currentPoint.Row - 1, currentPoint.Column));
            }

            RecursiveBreadthFirstSearch(queue);


            return queue;

        }

        public Stack<Point> GetPathToFollow()
        {
            if (this.FoundStackPath == null)
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
