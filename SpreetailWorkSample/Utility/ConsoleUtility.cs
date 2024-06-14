using System.Reflection;
using System;

namespace SpreetailWorkSample.Utility
{
    public static class ConsoleUtility
    {
        public const string EMPTY_SET = "empty set";
        public const string KEY_NOT_EXIST = "ERROR, key does not exist.";
        public const string MEMBER_NOT_EXIST = "ERROR, member does not exist.";

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
