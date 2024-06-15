
namespace SpreetailWorkSample.Utility
{
    public interface IConsoleHelper
    {
        public string ReadWithPrefix();
        public void WriteLineWithPrefix(string message);
        public void WriteLineWithPrefix(int lineNumber, string message);

    }
}
