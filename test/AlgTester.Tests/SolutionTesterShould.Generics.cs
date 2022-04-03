using AlgTester.API;
using NUnit.Framework;

namespace AlgTester.Tests
{
    internal static class GenericMethods
    {	
        public static string Solution_P1(int arr)
        {
            return "0";
        }
        public static string Solution_P2(int a, int b)
        {
            return "0";
        }
        public static string Solution_P3(int a, int b, int c)
        {
            return "0";
        }
        public static string Solution_P4(int a, int b, int c, int d)
        {
            return "0";
        }
        public static string Solution_P5(int a, int b, int c, int d, int e)
        {
            return "0";
        }
        public static string Solution_P6(int a, int b, int c, int d, int e, int f)
        {
            return "0";
        }
    }

    public partial class SolutionTesterShould
    {	
        [Test]
        public void Support_AllGenericFunctions()
        {
            /**
             * This test should always pass if they compile
             * If they don't compile, at least one generic pattern is not being completely supported
            **/
            
            {	
                var s1 = GenericMethods.Solution_P1;
                SolutionTester.New()
                    .WithSolution(s1)
                    .WithTestCase(0, "0")
                    .WithStringTestCase("[0]", @"[""0""]")
                    .WithPresenter(new NUnitTestResultsPresenter())
                    .WithStringTestCase("[0]", @"[""0""]")
                    .WithTestCase(1, "0")
                    .Run();
            }

            {	
                var s2 = GenericMethods.Solution_P2;
                SolutionTester.New()
                    .WithSolution(s2)
                    .WithTestCase(0, 0, "0")
                    .WithPresenter(new NUnitTestResultsPresenter())
                    .WithStringTestCase("[0, 0]", @"[""0""]")
                    .WithTestCase(1, 1, "0")
                    .Run();
            }

            {	
                var s3 = GenericMethods.Solution_P3;
                SolutionTester.New()
                    .WithSolution(s3)
                    .WithTestCase(0, 0, 0, "0")
                    .WithPresenter(new NUnitTestResultsPresenter())
                    .WithStringTestCase("[0, 0, 0]", @"[""0""]")
                    .WithTestCase(1, 1, 1, "0")
                    .Run();
            }

            {	
                var s4 = GenericMethods.Solution_P4;
                SolutionTester.New()
                    .WithSolution(s4)
                    .WithTestCase(0, 0, 0, 0, "0")
                    .WithPresenter(new NUnitTestResultsPresenter())
                    .WithStringTestCase("[0, 0, 0, 0]", @"[""0""]")
                    .WithTestCase(1, 1, 1, 1, "0")
                    .Run();
            }

            {	
                var s5 = GenericMethods.Solution_P5;
                SolutionTester.New()
                    .WithSolution(s5)
                    .WithTestCase(0, 0, 0, 0, 0, "0")
                    .WithPresenter(new NUnitTestResultsPresenter())
                    .WithStringTestCase("[0, 0, 0, 0, 0]", @"[""0""]")
                    .WithTestCase(1, 1, 1, 1, 1, "0")
                    .Run();
            }

            {	
                var s6 = GenericMethods.Solution_P6;
                SolutionTester.New()
                    .WithSolution(s6)
                    .WithTestCase(0, 0, 0, 0, 0, 0, "0")
                    .WithPresenter(new NUnitTestResultsPresenter())
                    .WithStringTestCase("[0, 0, 0, 0, 0, 0]", @"[""0""]")
                    .WithTestCase(1, 1, 1, 1, 1, 1, "0")
                    .Run();
            }
        }

    }
}