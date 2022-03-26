using System;

namespace AlgTesterRuntime.Core
{
    /// <summary>
    /// Marks method as solution
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class SolutionAttribute : Attribute 
    {	
    }
}