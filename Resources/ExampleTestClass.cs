using Test_Run_Minus.Core.Test_Results;
using Test_Run_Minus.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Run_Minus.Resources
{
    internal class ExampleTestClass
    {
        [TestClass("My Other Test Class", 1)]
        public class MyOtherTestClass
        {
            [TestMethod("My Other Test A", 0)]
            public TestResult MyTestMethodA()
            {
                return new TestResult("Test passed with no defects", 0);
            }

            [TestMethod("My Other Test B", 1)]
            public TestResult MyTestMethodB()
            {
                return new TestResult("Test failed with no defects", 0);
            }

            [TestMethod("My Other Test C", 2)]
            public TestResult MyTestMethodC()
            {
                return new TestResult("Test passed with no defects", 0);
            }

            [TestMethod("My Other Test D", 3)]
            public TestResult MyTestMethodD()
            {
                return new TestResult("Test passed with no defects", 0);
            }
        }

        [TestClass("My Test Class", 1)]
        public class MyExtraTestClass
        {
            [TestMethod("My Test A", 0)]
            public TestResult MyTestMethodA()
            {
                return new TestResult("Test passed with no defects", 1);
            }

            [TestMethod("My Test B", 1)]
            public TestResult MyTestMethodB()
            {
                return new TestResult("Test failed with no defects", 2);
            }

            [TestMethod("My Test C", 2)]
            public TestResult MyTestMethodC()
            {
                return new TestResult("Test passed with no defects", 1);
            }

            [TestMethod("My Test D", 3)]
            public TestResult MyTestMethodD()
            {
                return new TestResult("Test passed with no defects", 1);
            }
        }

    }
}
