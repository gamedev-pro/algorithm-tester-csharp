using AlgTester.Core;
using NUnit.Framework;

namespace AlgTester.Tests
{
    internal static class Solutions
    {	
        public static int Solution_Int(int arr)
        {
            return 0;
        }
    }

    public class SolutionTesterShould
    {
        [Test]
        public void Pass_When_ResultIsExpected()
        {
            var s = Solutions.Solution_Int;
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
            var s = Solutions.Solution_Int;
            var solTester = SolutionTesterUtils.NewSolutionTester(s, new TestCase[]
            {
                new TestCase
                {
                    Input = new object[] { 0 },
                    Output = new object[] { 0 }
                }
            }).Build();

            Assert.Throws<NUnit.Framework.AssertionException>(() => solTester.Run());
        }
    }
}