using Test_Run_Minus.Core.Test_Results;
using Test_Run_Minus.Core.Attributes;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Fragment;

public static class Program
{
    public static async Task Main()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        List<Type> types = assembly.GetTypes().Where(t => t.GetCustomAttribute(typeof(TestClassAttribute)) is not null).ToList();
        Console.WriteLine($"Test Classes Found: {types.Count}\n");
        Dictionary<string, Task<TestResult>> testPairs = new();
        foreach (var type in types)
        {
            var methods = type.GetMethods().Where(t => t.GetCustomAttribute(typeof(TestMethodAttribute)) is not null).ToList();
            object? obj = Activator.CreateInstance(type);
            if (obj is null)
                continue;
            foreach (var method in methods)
            {
                var attrib = method.GetCustomAttribute<TestMethodAttribute>();
                if (attrib is null)
                    continue;
                Task<TestResult> task = Task.Run(() => {
                    if (method.Invoke(obj, null) is not TestResult result)
                        result = new TestResult("Not a test result", 0);
                    return result;
                });
                testPairs.Add(attrib.TestName, task);
            }

            await Task.WhenAll(testPairs.Values);
            Console.WriteLine($"Test Class: {type.Name}");
            Console.WriteLine($"Tests Found: {testPairs.Values.Count}");
            foreach (var test in testPairs)
            {
                TestResult result = test.Value.Result;
                Console.WriteLine();
                Console.WriteLine($"  {test.Key}:");
                Console.WriteLine($"    --> Result: {result.ResultCode}");
                Console.WriteLine($"    --> {result.Message}");
            }
            Console.WriteLine();
            testPairs.Clear();
        }
    }
}
//Todo: Extract this all out into generator and processor classes, reduce the amount of data cached where possible