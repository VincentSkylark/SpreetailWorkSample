using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreetailWorkSample.Utility
{
    public static class ConsoleUtility
    {
        public static void InvalidArguments(int argsLength)
        {
            Console.WriteLine($"Invalid number of arguments. Expected {argsLength} {(argsLength > 1 ? "arguments" : "argument")}");
        }
    }
}
