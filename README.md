<h1 align="center"> AlgTester </h1>
<p align="center"><em> Simple and flexible API to run Coding Challenge solutions in your IDE. Supports test files. </em></p>

## Installation

TODO

## How to use

### Using a test file
1. Create a class and function for your coding challenge solution
```c#
public class ExampleSolution
{
    public int Solution(int[] arr, int n)
    {	
        return 0;
    }
}
```

2. Create a test file with the name formar `{SolutionClass}_Tests.txt` (i.e ExampleSolution_Tests.txt), with the following format:
   - Each test case in one line
   - Input and outputs are in [] and separated by ;
   - All base types are supported as expected (i.e 3 is `int`, 3.2 is `float`, "3.2" is `string`)
   - For instance a test file for the above `ExampleSolution.Solution` function would be

```
[ [1, 2, 3 ], 4 ];[ 0 ]
[ [2, -10, 4 ], 4 ];[ 3 ]
```

3. Run your solution
```c#
using AlgTester.API;

// Save the function you want to test in a variable (it will help C# auto resolve the correct method call)
var solutionFunc = ExampleSolution.Solution;
// Run your tests
// OBS: It will automatically pick a file named ExampleSolution_Tests.txt
SolutionTester.New()
    .WithSolution(solutionFunc)
    .Run();
```

4. Expected Output

TODO

