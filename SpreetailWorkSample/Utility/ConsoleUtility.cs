using System.Reflection;
using System;

namespace SpreetailWorkSample.Utility
{
    public static class ConsoleUtility
    {
        public static string ReadWithPrefix()
        {
            Console.Write("> ");
            return Console.ReadLine().Trim();
        }

        public static void WriteLineWithPrefix(string message)
        {
            Console.WriteLine($") {message}");
        }

        public static void WriteLineWithPrefix(int lineNumber, string message)
        {
            Console.WriteLine($"{lineNumber}) {message}");
        }
    }
}
