using NUnit.Framework;
using Assignment2;
using System;

namespace TestLibrary
{

    /// <summary>
    /// Maze.Test - A class for testing the Maze class
    /// 
    /// Assignment:     #2
    /// Course:         ADEV-3001
    /// Date Created:   Sept. 18th, 2019
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

        string basicMazeOutput = "WWWWWWWWWWWWW\n" +
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

        string basicMazeSearched = "WWWWWWWWWWWWW\n" +
                                    "W.    W     W\n" +
                                    "W.WWW W WWW W\n" +
                                    "W.W       W W\n" +
                                    "W.WWWWWWW WWW\n" +
                                    "W...WVVVW   W\n" +
                                    "WWW.WVWWW...W\n" +
                                    "W...VVW...WEW\n" +
                                    "W.WWWWW.WVWWW\n" +
                                    "W.......WVVVW\n" +
                                    "WWWWWWWWWWWWW";

        string basicMazeNoExitSearched = "No exit found in maze!\n\n" +
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

        string stringPath = "Path to follow from Start [1, 1] to Exit [7, 11] - 27 steps:\n" +
                            "[1, 1]\n[2, 1]\n[3, 1]\n[4, 1]\n[5, 1]\n[5, 2]\n[5, 3]\n[6, 3]\n" +
                            "[7, 3]\n[7, 2]\n[7, 1]\n[8, 1]\n[9, 1]\n[9, 2]\n[9, 3]\n[9, 4]\n" +
                            "[9, 5]\n[9, 6]\n[9, 7]\n[8, 7]\n[7, 7]\n[7, 8]\n[7, 9]\n[6, 9]\n" +
                            "[6, 10]\n[6, 11]\n[7, 11]\n";

        Stack<Point> stackPath;

        private Point startingPoint;
        private Point endingPoint;

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
            stackPath = new Stack<Point>();
            stackPath.Push(new Point(7, 11));
            stackPath.Push(new Point(6, 11));
            stackPath.Push(new Point(6, 10));
            stackPath.Push(new Point(6, 9));
            stackPath.Push(new Point(7, 9));
            stackPath.Push(new Point(7, 8));
            stackPath.Push(new Point(7, 7));
            stackPath.Push(new Point(8, 7));
            stackPath.Push(new Point(9, 7));
            stackPath.Push(new Point(9, 6));
            stackPath.Push(new Point(9, 5));
            stackPath.Push(new Point(9, 4));
            stackPath.Push(new Point(9, 3));
            stackPath.Push(new Point(9, 2));
            stackPath.Push(new Point(9, 1));
            stackPath.Push(new Point(8, 1));
            stackPath.Push(new Point(7, 1));
            stackPath.Push(new Point(7, 2));
            stackPath.Push(new Point(7, 3));
            stackPath.Push(new Point(6, 3));
            stackPath.Push(new Point(5, 3));
            stackPath.Push(new Point(5, 2));
            stackPath.Push(new Point(5, 1));
            stackPath.Push(new Point(4, 1));
            stackPath.Push(new Point(3, 1));
            stackPath.Push(new Point(2, 1));
            stackPath.Push(new Point(1, 1));
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

        //#region PrintMaze()
        /////// <summary>
        /////// Tests PrintMaze() returns a string version of the maze.
        /////// </summary>
        [Test]
        public void PrintMaze_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);

            String mazeOutput = maze.PrintMaze();

            Assert.That(mazeOutput, Is.EqualTo(basicMazeOutput));
        }
        //#endregion

        //#region DepthFirstSearch()
        /////// <summary>
        /////// Tests DepthFirstSearch() returns appropriate error string when used on a maze without an exit.
        /////// </summary>
        [Test]
        public void DepthFirstSearch_maze_with_no_exit_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMazeNoExit);

            string mazeOutput = maze.DepthFirstSearch();
            Assert.That(mazeOutput, Is.EqualTo(basicMazeNoExitSearched));
        }

        /// <summary>
        /// Tests DepthFirstSearch() returns path to follow string when used on a maze with an exit.
        /// </summary>
        [Test]
        public void DepthFirstSearch_maze_with_exit_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);

            string mazeOutput = maze.DepthFirstSearch();
            Assert.That(mazeOutput, Is.EqualTo(stringPath + basicMazeSearched));
        }
        //#endregion

        //#region GetPathToFollow()
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
        ///// Tests GetPathToFollow() returns an empty stack when no exit found.
        ///// </summary>
        [Test]
        public void GetPathToFollow_on_maze_with_no_exit_returns_empty_stack_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMazeNoExit);
            maze.DepthFirstSearch();
            Stack<Point> path = maze.GetPathToFollow();
            Assert.That(path.IsEmpty(), Is.True);
        }

        ///// <summary>
        ///// Tests GetPathToFollow() returns a stack containing the path used from start (at Top()) to end (at bottom).
        ///// </summary>
        [Test]
        public void GetPathToFollow_on_maze_with_exit_returns_ordered_stack_path_Test()
        {
            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);
            maze.DepthFirstSearch();
            Stack<Point> path = maze.GetPathToFollow();
            Assert.That(path.IsEmpty(), Is.False);

            while (!path.IsEmpty())
            {
                Assert.That(path.Pop().ToString(), Is.EqualTo(stackPath.Pop().ToString()));
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
            maze.DepthFirstSearch();
            Stack<Point> path = maze.GetPathToFollow();
            Assert.That(path.IsEmpty(), Is.False);

            while (!path.IsEmpty())
            {
                Assert.That(path.Pop().ToString(), Is.EqualTo(stackPath.Pop().ToString()));
            }

            ResetReverseStack();

            Stack<Point> path2 = maze.GetPathToFollow();
            Assert.That(path2.IsEmpty(), Is.False);

            while (!path2.IsEmpty())
            {
                Assert.That(path2.Pop().ToString(), Is.EqualTo(stackPath.Pop().ToString()));
            }
        }
        //#endregion
    }
}