using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Run_Minus.Core.Reflection
{
    internal class AssemblyInspector
    {

    }
}
/* "Generic" inspector which handles inspecting assemblies based on a provided Predicate
 This will later be used to ensure that the assmeblies contain classes with the [TestClass] attribute

Todo: Research a way of flagging assemblies as "Test Assemblies" to avoid overhead of reflecting through the assembly to find test classes
 */
