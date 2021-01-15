using NUnit.Framework;
using System;

namespace TestLibrary
{
    [TestFixture]
    public class NUnitTest
    {
        /// <summary>
        /// This one test will pass and you should see a green check mark in your Test Explorer!
        /// Go to: Test -> Test Explorer
        /// If this test is not showing up:
        /// 1) right-click on your project
        /// 2) Select Manage Nu-Get Packages ...
        /// 3) Click on Browse
        /// 4) Search for NUnit
        /// 5) Install the first two packages: NUnit and NUnit3TestAdaptor
        /// 6) Now try to run the tests again!
        /// 7) Still not working?  Did you create a Console Application with .net framework!? or .new core?  we use the .net framework for our assignments!
        /// </summary>
        [Test]
        public void This_Test_Will_Always_Pass_Test()
        {
            Assert.IsTrue(true);
        }
    }
}