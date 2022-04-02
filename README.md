<h1 align="center"> AlgTester </h1>
<p align="center"><em> Simple and flexible API to run Coding Challenge solutions in your IDE. Supports test files. </em></p>

## Installation

- Go your .csproj file and add
```
  <ItemGroup>
    <PackageReference Include="GameDevPro.AlgTester" Version="1.0.0" />
  </ItemGroup>
```

## How to use

You can just create any **static function** for your Coding Challenge and run it like this

- C# 10 and above

```c#
using AlgTester.API;//Include lib

public static int MyCodingChallengeSolution(int n, int[] arr)
{	
    return 0;
}

// Save the function you want to test in a variable (it will help C# auto resolve the correct method call)
var solutionFunc = MyCodingChallengeSolution;
// Run your tests
SolutionTester.New()
    .WithSolution(solutionFunc)
    .WithTestCase(2, new int[] { 1, 3 }, 0) // Type safe Input and output
    .WithTestCase(3, new int[] { 2, 3, 5 }, 0)
    .Run();//Run tests!
```

- C# 9 and below

```c#
using AlgTester.API;//Include lib

public static class Solution
{	
    public static int MyCodingChallengeSolution(int n, int[] arr)
    {	
        return 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solutionFunc = Solution.MyCodingChallengeSolution;
        SolutionTester.New()
            //No implicity generic method resolution for C# 9.0
            .WithSolution<int, int[], int>(solutionFunc)
            .WithTestCase(2, new int[] { 1, 3 }, 0) // Type safe Input and output
            .WithTestCase(3, new int[] { 2, 3, 5 }, 0)
            .Run();
    }
}
```

## Using a Test File

For testing multiple inputs, it's usually much easier to use a separate test file with inputs and outputs.

AlgTester automatically searches for a file matching the following patterns (in order):
- `{ClassName}_{MethodName}_Tests.txt`
- `{MethodName}_Tests.txt`
- `{ClassName}_Tests.txt`

For instance, if we want to use a test file for `MyCodingChallengeSolution`, we can create a file named **MyCodingChallengeSoluiton_Tests.txt** with the following content:

```
[ 2, [ 1, 3 ] ];[ 0 ]
[ 3, [ 2, 3, 5] ];[ 0 ]
```

Which would be equivalent to the following in C#
```c#
.WithTestCase(2, new int[] { 1, 3 }, 0)
.WithTestCase(3, new int[] { 2, 3, 5 }, 0)
```

Then, to run your solution with the test file you just:

```c#
var solutionFunc = MyCodingChallengeSolution;
// Run your tests
SolutionTester.New()
    .WithSolution(solutionFunc)
    .Run();//Alg tester automatically picks up the test file
```