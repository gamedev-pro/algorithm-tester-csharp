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
    .WithTestCase(3, new int[] { 2, 3, 5 }, 1) // Another test case (this one will fail)
    .WithTestCase(3, new int[] { 2, 3, 5 }, 0) // and another :)
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
            .WithTestCase(3, new int[] { 2, 3, 5 }, 1) // Another test case (this one will fail)
            .WithTestCase(3, new int[] { 2, 3, 5 }, 0) // and another :)
            .Run();
    }
}
```

If you run your project, you should get the following output:
```diff
+Test 0: Input = [2,[1,3]], Expected = [0], Actual = [0]
-Test 1: Input = [3,[2,3,5]], Expected = [1], Actual = [0]
+Test 2: Input = [3,[2,3,5]], Expected = [0], Actual = [0]
```

</br></br>

## Using Strings

Though type safety is *awesome*, some data structures are more cubbersome to define, such as LinkedList and Dictionary. To make testing these cases easier, AlgTester support passing inputs and outputs as strings, you can also [use a Test File](#Using-a-Test-File)

```c#
using AlgTester.API;

static LinkedList<int> MyCodingChallengeSolution(int number, LinkedList<int> list)
{
    return list;
}

var solutionFunc = MyCodingChallengeSolution;

SolutionTester.New()
    .WithSolution(solutionFunc)
    .WithTestCase(10, new LinkedList<int>(new int[] { 1, 2, 3 }), new LinkedList<int>(new int[] { 1, 2, 3 }))
    //This is equivalent to the above test case
    .WithStringTestCase(input: @"[ 10, [1,2,3] ]", output: @"[ [1,2,3] ]")
    .Run()
```

### String Test Case Rules

- All inputs are passed together, grouped by `[]`. Output is only one, but also grouped by `[]`.
- Values follow *JSON notation*, which means
  - `10` is an `int`
  - `10.23` is a `float`
  - `""10""` is a `string` (we just need to scape the `"`)
  - `'10'` is a `char`
  - `true` is a `bool`
  - `[1, 2, 3]` is an array of `ints` (or `List<int>`, `LinkedList<int>`, `Queue<int>`, `Stack<int>`, `HashSet<int>`)
  - `{ ""1"": 10, ""4"": 3 }` is a `Dictionary<string, int>`


## Running specific tests

When debugging a coding challenge, you often want to run only the test cases that are failing. AlgTester supports running only failed tests.

```c#
var solutionFunc = MyCodingChallengeSolution;
SolutionTester.New()
    .WithSolution(solutionFunc)
    .WithTestCase(2, new int[] { 1, 3 }, 0)
    .WithTestCase(3, new int[] { 2, 3, 5 }, 1)// This test will fail
    .WithTestCase(3, new int[] { 1, 3, 2 }, 0)
    .WithTestCase(10, new int[] { 1, 3, 2 }, 1)// This one will also fail
    .ShowFailedTestsOnly()
    .Run();//runs tests with index 1 and 3 (second and forth tests)
```

You should then get something like this:

```diff
Results for Test Suite: MyCodingChallengeSolution
- Test 1: Input = [3,[2,3,5]], Expected = [1], Actual = [0]
+ Test 3: Input = [10,[1,3,2]], Expected = [0], Actual = [1]
```
You can also run filter tests by index if you like

```c#
var solutionFunc = MyCodingChallengeSolution;
SolutionTester.New()
    .WithSolution(solutionFunc)
    .WithTestCase(2, new int[] { 1, 3 }, 0)
    .WithTestCase(3, new int[] { 2, 3, 5 }, 1)
    .WithTestCase(3, new int[] { 1, 3, 2 }, 0)
    .WithTestCase(10, new int[] { 1, 3, 2 }, 1)
    .Run(0, 3);//runs tests with index 0 and 3 (first and forth tests)
```

```diff
Results for Test Suite: MyCodingChallengeSolution
+Test 0: Input = [2,[1, 3]], Expected = [0], Actual = [0]
-Test 3: Input = [10,[1,3,2]], Expected = [0], Actual = [1]
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

*Note: test files use JSON Notation, see [this section for more details](#string-test-case-rules)*

Then, to run your solution with the test file you just:

```c#
var solutionFunc = MyCodingChallengeSolution;
// Run your tests
SolutionTester.New()
    .WithSolution(solutionFunc)
    .Run();//Alg tester automatically picks up the test file
```

You should see the following result

```diff
Results for Test Suite: MyCodingChallengeSolution
+Test 0: Input = [ 2,[1, 3] ], Expected = [0], Actual = [0]
+Test 1: Input = [ 3,[2, 3, 5] ], Expected = [0], Actual = [0]
```