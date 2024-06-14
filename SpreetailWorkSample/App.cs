using SpreetailWorkSample.Commands;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample
{
    public class App
    {
        private readonly Dictionary<string, ICommand> _commands;
        public App(Dictionary<string, ICommand> commands)
        {
            _commands = commands;
        }

        public void Run()
        {
            while (true)
            {
                var input = ConsoleUtility.ReadWithPrefix();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var parts = input.Split(' ');
                if (parts.Length > 0)
                {
                    var commandName = parts[0].ToLower();
                    var args = parts.Skip(1).ToArray();

                    if (_commands.ContainsKey(commandName))
                    {
                        _commands[commandName].Execute(args);
                    }
                    else
                    {
                        ConsoleUtility.WriteLineWithPrefix("Invalid command");
                    }
                }
                else
                {
                    ConsoleUtility.WriteLineWithPrefix("No command entered");
                }
            }
        }
    }
}
