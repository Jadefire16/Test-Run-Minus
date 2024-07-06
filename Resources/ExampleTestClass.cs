using Test_Run_Minus.Core.Execution.Results;
using Test_Run_Minus.Core.Execution.Attributes;
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
            public void MyTestMethodA()
            {
            }

            [TestMethod("My Other Test B", 1)]
            public void MyTestMethodB()
            {
            }

            [TestMethod("My Other Test C", 2)]
            public void MyTestMethodC()
            {
            }

            [TestMethod("My Other Test D", 3)]
            public void MyTestMethodD()
            {
            }
        }

        [TestClass("My Test Class", 1)]
        public class MyExtraTestClass
        {
            [TestMethod("My Test A", 0)]
            public void MyTestMethodA()
            {
            }

            [TestMethod("My Test B", 1)]
            public void MyTestMethodB()
            {
            }

            [TestMethod("My Test C", 2)]
            public void MyTestMethodC()
            {
            }

            [TestMethod("My Test D", 3)]
            public void MyTestMethodD()
            {
            }
        }

    }
}
