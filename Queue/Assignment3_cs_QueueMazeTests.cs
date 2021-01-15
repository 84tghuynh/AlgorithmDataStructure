using NUnit.Framework;
using Assignment3;
using System;

namespace TestLibrary { 



    /// <summary>
    /// Maze.Test - A class for testing the Maze class
    /// 
    /// Assignment:     #3
    /// Course:         ADEV-3001
    /// Date Created:   March 20th, 2018
    /// 
    /// Revision Log
    /// Who         When        Reason
    /// ----------- ----------- ---------------
    /// 
    /// @author: Scott Wachal
    /// @version 1.0
    /// </summary>
[TestFixture]
    public class MazeTest
    {
        // Put the maze files to test inside of your BIN\DEBUG directory of the test project:
        private string simpleWithExit = AppDomain.CurrentDomain.BaseDirectory + "simpleWithExit.maze";
        private string simpleWithoutExit = AppDomain.CurrentDomain.BaseDirectory + "simpleWithoutExit.maze";

        private Point startingPoint;
        private Point endingPoint;

        string basicMazeOutput =
            "WWWWWWWWWWWWW\n" +
            "W     W     W\n" +
            "W WWW W WWW W\n" +
            "W W       W W\n" +
            "W WWWWWWW WWW\n" +
            "W   W   W   W\n" +
            "WWW W WWW   W\n" +
            "W     W   WEW\n" +
            "W WWWWW W WWW\n" +
            "W       W   W\n" +
            "WWWWWWWWWWWWW";

        string basicMazeBreadthSearched =
            "WWWWWWWWWWWWW\n" +
            "W.....WVVVVVW\n" +
            "WVWWW.WVWWWVW\n" +
            "WVWVV.....W W\n" +
            "WVWWWWWWW.WWW\n" +
            "WVVVWVVVW.VVW\n" +
            "WWWVWVWWW...W\n" +
            "WVVVVVWVVVWEW\n" +
            "WVWWWWW WVWWW\n" +
            "WVVVVV  WV  W\n" +
            "WWWWWWWWWWWWW";

        string basicMazeNoExitSearched =
            "No exit found in maze!\n\n" +
            "WWWWWWWWWWWWW\n" +
            "WVVVVVWVVVVVW\n" +
            "WVWWWVWVWWWVW\n" +
            "WVWVVVVVVVWVW\n" +
            "WVWWWWWWWVWWW\n" +
            "WVVVWVVVWVVVW\n" +
            "WWWVWVWWWVVVW\n" +
            "WVVVVVWVVVWVW\n" +
            "WVWWWWWVWVWWW\n" +
            "WVVVVVVVWVVVW\n" +
            "WWWWWWWWWWWWW";

        string breadthStringPath =
            "Path to follow from Start [1, 1] to Exit [7, 11] - 17 steps:\n" +
            "[1, 1]\n[1, 2]\n[1, 3]\n[1, 4]\n[1, 5]\n[2, 5]\n[3, 5]\n[3, 6]\n" +
            "[3, 7]\n[3, 8]\n[3, 9]\n[4, 9]\n[5, 9]\n[6, 9]\n[6, 10]" +
            "\n[6, 11]\n[7, 11]\n";

        Stack<Point> breathStackPath;

        char[][] basicMaze;
        char[][] basicMazeNoExit;

        /// <summary>
        /// Sets up the mazes used for the tests.
        /// </summary>
        [SetUp]
        public void Init()
        {
            basicMaze = new char[11][];

            startingPoint = new Point(1, 1);
            endingPoint = new Point(7, 11);

            basicMaze[0] = "WWWWWWWWWWWWW".ToCharArray();
            basicMaze[1] = "W     W     W".ToCharArray();
            basicMaze[2] = "W WWW W WWW W".ToCharArray();
            basicMaze[3] = "W W       W W".ToCharArray();
            basicMaze[4] = "W WWWWWWW WWW".ToCharArray();
            basicMaze[5] = "W   W   W   W".ToCharArray();
            basicMaze[6] = "WWW W WWW   W".ToCharArray();
            basicMaze[7] = "W     W   WEW".ToCharArray();
            basicMaze[8] = "W WWWWW W WWW".ToCharArray();
            basicMaze[9] = "W       W   W".ToCharArray();
            basicMaze[10] = "WWWWWWWWWWWWW".ToCharArray();


            basicMazeNoExit = new char[11][];
            basicMazeNoExit[0] = "WWWWWWWWWWWWW".ToCharArray();
            basicMazeNoExit[1] = "W     W     W".ToCharArray();
            basicMazeNoExit[2] = "W WWW W WWW W".ToCharArray();
            basicMazeNoExit[3] = "W W       W W".ToCharArray();
            basicMazeNoExit[4] = "W WWWWWWW WWW".ToCharArray();
            basicMazeNoExit[5] = "W   W   W   W".ToCharArray();
            basicMazeNoExit[6] = "WWW W WWW   W".ToCharArray();
            basicMazeNoExit[7] = "W     W   W W".ToCharArray();
            basicMazeNoExit[8] = "W WWWWW W WWW".ToCharArray();
            basicMazeNoExit[9] = "W       W   W".ToCharArray();
            basicMazeNoExit[10] = "WWWWWWWWWWWWW".ToCharArray();

            ResetReverseStack();
        }

        private void ResetReverseStack()
        {
            breathStackPath = new Stack<Point>();
            breathStackPath.Push(new Point(7, 11));
            breathStackPath.Push(new Point(6, 11));
            breathStackPath.Push(new Point(6, 10));
            breathStackPath.Push(new Point(6, 9));
            breathStackPath.Push(new Point(5, 9));
            breathStackPath.Push(new Point(4, 9));
            breathStackPath.Push(new Point(3, 9));
            breathStackPath.Push(new Point(3, 8));
            breathStackPath.Push(new Point(3, 7));
            breathStackPath.Push(new Point(3, 6));
            breathStackPath.Push(new Point(3, 5));
            breathStackPath.Push(new Point(2, 5));
            breathStackPath.Push(new Point(1, 5));
            breathStackPath.Push(new Point(1, 4));
            breathStackPath.Push(new Point(1, 3));
            breathStackPath.Push(new Point(1, 2));
            breathStackPath.Push(new Point(1, 1));
        }

        #region Constructor Tests
        /// <summary>
        /// Checks to make sure the constructor instantializes the appropriate variables
        /// </summary>
        [Test]
        public void Maze_Constructor_existing_maze_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);

            Assert.That(maze, Is.Not.Null);
            Assert.That(maze.RowLength, Is.EqualTo(basicMaze.Length));
            Assert.That(maze.ColumnLength, Is.EqualTo(basicMaze[0].Length));
            Assert.That(maze.StartingPoint.Row, Is.EqualTo(startingPoint.Row));
            Assert.That(maze.StartingPoint.Column, Is.EqualTo(startingPoint.Column));

            char[][] existingMaze = maze.GetMaze();

            for (int i = 0; i < existingMaze.Length; i++)
            {
                for (int k = 0; k < existingMaze[i].Length; k++)
                {
                    Assert.That(existingMaze[i][k], Is.EqualTo(basicMaze[i][k]));
                }
            }
        }

        /// <summary>
        /// If the existing maze starts on the exit, throw an exception
        /// </summary>
        [Test]
        public void Maze_Constructor_existingMaze_throws_error_on_Exit_as_starting_point_Test()
        {
            Maze maze;
            Assert.That(() => maze = new Maze(endingPoint.Row, endingPoint.Column, basicMaze), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// If the existing maze starts in a wall, throw an exception
        /// </summary>
        [Test]
        public void Maze_Constructor_existingMaze_throws_error_on_Wall_as_starting_point_Test()
        {
            Maze maze;
            Assert.That(() => maze = new Maze(0, 0, basicMaze), Throws.Exception.TypeOf<ApplicationException>());
        }
        /// <summary>
        /// If the existing maze has an invalid Row, throw an exception
        /// </summary>
        [Test]
        public void Maze_Constructor_existingMaze_throws_error_on_negative_row_Test()
        {
            Maze maze;
            Assert.That(() => maze = new Maze(-1, startingPoint.Column, basicMaze), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }
        /// <summary>
        /// If the existing maze has an invalid Column, throw an exception
        /// </summary>
        [Test]
        public void Maze_Constructor_existingMaze_throws_error_on_negative_column_Test()
        {
            Maze maze;
            Assert.That(() => maze = new Maze(startingPoint.Row, -1, basicMaze), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }
        /// <summary>
        /// If the existing maze has an invalid Row, throw an exception
        /// </summary>
        [Test]
        public void Maze_Constructor_existingMaze_throws_error_on_row_value_greater_than_maze_Test()
        {
            Maze maze;
            Assert.That(() => maze = new Maze(basicMaze.Length, startingPoint.Column, basicMaze), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }
        /// <summary>
        /// If the existing maze has an invalid Column, throw an exception
        /// </summary>
        [Test]
        public void Maze_Constructor_existingMaze_throws_error_on_column_value_greater_than_maze_Test()
        {
            Maze maze;
            Assert.That(() => maze = new Maze(startingPoint.Row, basicMaze[0].Length, basicMaze), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /// <summary>
        /// Checks to make sure the constructor instantializes the appropriate variables from the file
        /// </summary>
        [Test]
        public void Maze_Constructor_file_maze_Test()
        {
            Maze maze = new Maze(simpleWithExit);

            Assert.That(maze, Is.Not.Null);

            // note that the file is the same maze as the hardcoded char array basicMaze
            Assert.That(maze.RowLength, Is.EqualTo(basicMaze.Length));
            Assert.That(maze.ColumnLength, Is.EqualTo(basicMaze[0].Length));
            Assert.That(maze.StartingPoint.Row, Is.EqualTo(startingPoint.Row));
            Assert.That(maze.StartingPoint.Column, Is.EqualTo(startingPoint.Column));

            char[][] fileMaze = maze.GetMaze();

            for (int i = 0; i < fileMaze.Length; i++)
            {
                for (int k = 0; k < fileMaze[i].Length; k++)
                {
                    Assert.That(fileMaze[i][k], Is.EqualTo(basicMaze[i][k]));
                }
            }
        }
        #endregion

        #region PrintMaze()
        ///// <summary>
        ///// Tests PrintMaze() returns a string version of the maze.
        ///// </summary>
        [Test]
        public void PrintMaze_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);

            String mazeOutput = maze.PrintMaze();

            Assert.That(mazeOutput, Is.EqualTo(basicMazeOutput));
        }
        #endregion

        #region BreadthFirstSearch()
        ///// <summary>
        ///// Tests BreadthFirstSearch() returns appropriate error string when used on a maze without an exit.
        ///// </summary>
        [Test]
        public void BreadthFirstSearch_maze_with_no_exit_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMazeNoExit);
            string mazeOutput = maze.BreadthFirstSearch();
            Assert.That(mazeOutput, Is.EqualTo(basicMazeNoExitSearched));
        }

        ///// <summary>
        ///// Tests BreadthFirstSearch() returns path to follow string when used on a maze with an exit.
        /////  NOTE: this is the one test that may be off, check your result, if it's reasonable output, 
        /////  it will pass my milestone
        ///// </summary>
        [Test]
        public void BreadthFirstSearch_maze_with_exit_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);

            string mazeOutput = maze.BreadthFirstSearch();
            Assert.That(mazeOutput, Is.EqualTo(breadthStringPath + basicMazeBreadthSearched));
        }
        #endregion

        #region GetPathToFollow()
        ///// <summary>
        ///// Tests GetPathToFollow() throws an exception when we have not yet searched the maze.
        ///// </summary>
        [Test]
        public void GetPathToFollow_before_search_throws_exception_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);
            Assert.That(() => maze.GetPathToFollow(), Throws.Exception.TypeOf<ApplicationException>());
        }

        ///// <summary>
        ///// Tests GetBreadthFirstPathToFollow() returns an empty stack when no exit found.
        ///// </summary>
        [Test]
        public void GetBreadthFirstPathToFollow_on_maze_with_no_exit_returns_empty_stack_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMazeNoExit);
            maze.BreadthFirstSearch();
            Stack<Point> path = maze.GetPathToFollow();
            Assert.That(path.IsEmpty(), Is.True);
        }

        ///// <summary>
        ///// Tests GetBreadthFirstPathToFollow() returns a stack containing the path used from start (at Top()) to end (at bottom).
        ///// </summary>
        [Test]
        public void GetBreadthFirstPathToFollow_on_maze_with_exit_returns_ordered_stack_path_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);
            maze.BreadthFirstSearch();
            Stack<Point> path = maze.GetPathToFollow();
            Assert.That(path.IsEmpty(), Is.False);

            while (!path.IsEmpty())
            {
                Assert.That(path.Pop().ToString(), Is.EqualTo(breathStackPath.Pop().ToString()));
            }
        }

        ///// <summary>
        ///// Tests GetPathToFollow() returns a stack containing the path used from start (at Top()) to end (at bottom), will work when run twice in a row!
        ////  Note: this test is to ensure you are not destroying your created Stack after running GetPathToFollow() the first time.
        ////  You should be returning a copy of the stack.
        ///// </summary>
        [Test]
        public void GetPathToFollow_works_the_same_way_when_run_twice_in_a_row_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);
            maze.BreadthFirstSearch();
            Stack<Point> path = maze.GetPathToFollow();
            Assert.That(path.IsEmpty(), Is.False);

            while (!path.IsEmpty())
            {
                Assert.That(path.Pop().ToString(), Is.EqualTo(breathStackPath.Pop().ToString()));
            }

            ResetReverseStack();

            Stack<Point> path2 = maze.GetPathToFollow();
            Assert.That(path2.IsEmpty(), Is.False);

            while (!path2.IsEmpty())
            {
                Assert.That(path2.Pop().ToString(), Is.EqualTo(breathStackPath.Pop().ToString()));
            }
        }
        #endregion
    }

}