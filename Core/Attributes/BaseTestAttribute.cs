using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Run_Minus.Core.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public abstract class BaseTestAttribute : Attribute
    {
        public string TestName { get; private set; }
        public int Identifier { get; private set; }

        public BaseTestAttribute(string testName, int identifier)
        {
            TestName = testName;
            Identifier = identifier;
        }
    }
}
