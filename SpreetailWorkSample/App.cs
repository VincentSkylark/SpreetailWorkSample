using SpreetailWorkSample.Commands;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample
{
    public class App
    {
        private readonly Dictionary<string, ICommand> _commands;
        private readonly IConsoleHelper _consoleHelper;
        public App(Dictionary<string, ICommand> commands)
        {
            _commands = commands;
            _consoleHelper = new ConsoleHelper();
        }

        public App(Dictionary<string, ICommand> commands, IConsoleHelper consoleHelper)
        {
            _commands = commands;
            _consoleHelper = consoleHelper;
        }

        public void Run()
        {
            while (true)
            {
                var input = _consoleHelper.ReadWithPrefix();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    _consoleHelper.WriteLineWithPrefix("Exiting...");
                    break;
                }

                if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (var command in _commands)
                    {
                        command.Value.Helper();
                    }
                    continue;
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
                        if (!string.IsNullOrEmpty(commandName))
                            _consoleHelper.WriteLineWithPrefix("Invalid command, use 'help' command to see the list of avaliable methods.");
                    }
                }
                else
                {
                    _consoleHelper.WriteLineWithPrefix("No command entered");
                }
            }
        }
    }
}
