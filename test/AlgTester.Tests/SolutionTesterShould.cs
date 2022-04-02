using System.IO;
using AlgTester.API;
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
            SolutionTester.DefaultPresenter = new NUnitTestResultsPresenter();
            //f***ing dotnet has inconsistent test directories: https://github.com/microsoft/vstest/issues/2004
            //TODO: Is there a way to set this via cli?
            Directory.SetCurrentDirectory($"{Directory.GetCurrentDirectory()}/../../../../../");
        }

        [Test]
        public void Pass_When_ResultIsExpected()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTester.New().WithSolution(s)
                .WithTestCase(0, 0)
                .Run();
        }

        [Test]
        public void Fail_When_ResultIsNotExpected()
        {
            var s = SolutionTesterTests.Solution;
            var solTester = SolutionTester.New()
                .WithSolution(s)
                .WithTestCase(0, 1)
                .Build();

            Assert.Throws<NUnit.Framework.AssertionException>(() => solTester.Run());
        }

        [Test]
        public void Run_WithAutoTestFile()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTester.New().WithSolution(s).WithAutoTestFile().Run();
        }

        [Test]
        public void Run_WithStringTestCase()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTester.New().WithSolution(s)
                .WithStringTestCase("[0]", "[0]")
                .Run();
        }

        [Test]
        public void Run_WithTestFilePath()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTester.New()
                .WithSolution(s)
                .WithTestFile("test/AlgTester.Tests/SolutionTesterTests_Tests.txt")
                .Run();
        }
        [Test]
        public void Run_WithPartialTestFilePath()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTester.New()
                .WithSolution(s)
                .WithTestFile("AlgTester.Tests/SolutionTesterTests_Tests.txt")
                .Run();
        }

        [Test]
        public void Run_WithTestFileName()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTester.New()
                .WithSolution(s)
                .WithTestFile("SolutionTesterTests_Tests.txt")
                .Run();
        }

        [Test]
        public void FilterTests()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTester.New()
                .WithSolution(s)
                .WithPresenter(new NUnitFilterTestsPresenter(2))
                .WithTestCase(0, 0)
                .WithTestCase(0, 0)
                .WithTestCase(0, 0)
                .WithTestCase(0, 0)
                .Run(1, 3);
        }
        [Test]
        public void RunAllTests_When_NoFilter()
        {
            var s = SolutionTesterTests.Solution;
            SolutionTester.New()
                .WithSolution(s)
                .WithPresenter(new NUnitFilterTestsPresenter(4))
                .WithTestCase(0, 0)
                .WithTestCase(0, 0)
                .WithTestCase(0, 0)
                .WithTestCase(0, 0)
                .Run();
        }

        [Test]
        public void Fail_If_FileDoesNotExists()
        {
            var s = SolutionTesterTests.Solution;
            Assert.Throws<System.ArgumentException>(() => SolutionTester.New().WithSolution(s).WithTestFile("Inexistent file.txt").Run());
        }
    }
}