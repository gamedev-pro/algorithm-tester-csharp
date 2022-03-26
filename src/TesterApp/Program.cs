
using AlgTester.Core;

namespace TesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Passa a solution func
            //Baseado na solution func, pega um arquivo .txt na mesma pasta
            //Aceita override
            // Talvez troque para mandar classe + attribute + builder pattern (SolutionTester)



            /* var solutionFunc = SolutionFunc<int[], int, int>.Get(FindRepeatedElement.FindRepeatingElement_Naive); */
            /* SolutionTester.Test("src/TesterApp/Solutions/FindRepeatedNumber/FindRepeatedElement_TestCases.txt", solutionFunc); */

            SolutionTesterV2.New<FindRepeatedElement, int[]>(
                "src/TesterApp/Solutions/FindRepeatedNumber/FindRepeatedElement_TestCases.txt")
                .Run();
        }
    }
}
