using System.IO;
using AlgTester.Core;
using NUnit.Framework;

namespace AlgTester.Tests
{
    internal static class SolutionTesterTests
    {	
        public static int Solution(int arr)
        {
            return 0;
        }
    }

    public class SolutionTesterShould
    {
        [OneTimeSetUp]
        public void Setup()
        {
            //f***ing dotnet has inconsistent test directories: https://github.com/microsoft/vstest/issues/2004
            //TODO: Is there a way to set this via cli?
            Directory.SetCurrentDirectory($"{Directory.GetCurrentDirectory()}/../../../../../");
        }

        [Test]
        public void Pass_When_ResultIsExpected()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTesterUtils.NewSolutionTester(s, new TestCase[]
            {
                new TestCase
                {
                    Input = new object[] { 0 },
                    Output = new object[] { 0 }
                }
            }).Run();
        }

        [Test]
        public void Fail_When_ResultIsNotExpected()
        {
            var s = SolutionTesterTests.Solution;
            var solTester = SolutionTesterUtils.NewSolutionTester(s, new TestCase[]
            {
                new TestCase
                {
                    Input = new object[] { 0 },
                    Output = new object[] { 1 }
                }
            }).Build();

            Assert.Throws<NUnit.Framework.AssertionException>(() => solTester.Run());
        }

        [Test]
        public void Run_WithAutoTestFile()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTesterUtils.NewSolutionTester(s).WithAutoTestFile().Run();
        }

        [Test]
        public void Run_WithTestFile()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTesterUtils.NewSolutionTester(s)
                .WithTestFile("test/AlgTester.Tests/SolutionTesterTests_Tests.txt")
                .Run();
        }

        [Test]
        public void Fail_If_FileDoesNotExists()
        {
            var s = SolutionTesterTests.Solution;
            Assert.Throws<System.ArgumentException>(() => SolutionTesterUtils.NewSolutionTester(s).WithTestFile("Inexistent file.txt").Run());
        }
    }
}