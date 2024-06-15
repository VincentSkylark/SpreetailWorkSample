
namespace SpreetailWorkSample.Utility
{

    public class ConsoleHelper : IConsoleHelper
    {
        public string ReadWithPrefix()
        {
            Console.Write("> ");
            return Console.ReadLine()?.Trim() ?? "exit";
        }

        public void WriteLineWithPrefix(string message)
        {
            Console.WriteLine($") {message}");
            return;
        }

        public void WriteLineWithPrefix(int lineNumber, string message)
        {
            Console.WriteLine($"{lineNumber}) {message}");
            return;
        }
    }
}
