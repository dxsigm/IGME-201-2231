using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// to add additional source files to a project
// right click on the project and select Add / Class...
// Name the new source file in the field at the bottom (it will default to something like Class1.cs)
// It will create the code using the same namespace as the project
// But is will add a new class of the name of the file
// If you named the file Utils.cs, it will add this line:
//             internal class Utils
// we need to extend the class across the multiple source files so that everything defined in the class
// is available across all of our source
// we do that first by making the class static, which it should be in the Program.cs
// then we add the "partial" keyword before "class" to indicate this file has a partial implementation of our class
namespace DataTypeConversion
{
    static internal partial class Program
    {
        // MyDivider() is available everywhere within the Program class, even in other source files
        // which extend the class
        static double MyDivider(double n1, double n2)
        {
            return 1;
        }
    }
}
