
namespace SpreetailWorkSample.Utility
{

    public class ConsoleHelper : IConsoleHelper
    {
        public virtual string ReadWithPrefix()
        {
            return ConsoleUtility.ReadWithPrefix();
        }

        public virtual void WriteLineWithPrefix(string message)
        {
            ConsoleUtility.WriteLineWithPrefix(message);
            return;
        }

        public virtual void WriteLineWithPrefix(int lineNumber, string message)
        {
            ConsoleUtility.WriteLineWithPrefix(lineNumber, message);
            return;
        }
    }
}
