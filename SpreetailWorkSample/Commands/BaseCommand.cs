using SpreetailWorkSample.Utility;
using System.Reflection;

namespace SpreetailWorkSample.Commands
{
    public class BaseCommand : ICommand
    {
        private readonly Delegate _method;
        private readonly IConsoleHelper _consoleHelper;

        public BaseCommand(Delegate method)
        {
            _method = method;
            _consoleHelper = new ConsoleHelper();
        }
        public void Execute(string?[] args)
        {
            if (_method == null)
            {
                _consoleHelper.WriteLineWithPrefix("Method does not exist");
                return;
            }

            MethodInfo methodInfo = _method!.GetMethodInfo();
            ParameterInfo[] parameters = methodInfo.GetParameters();

            if (args == null) args = Array.Empty<string>();

            if (parameters.Length != args.Length)
            {
                if (parameters.Length == 0)
                {
                    _consoleHelper.WriteLineWithPrefix($"Invalid usage of {methodInfo.Name} command. No arguments expected.");
                }
                else
                {
                    _consoleHelper.WriteLineWithPrefix($"Invalid usage of {methodInfo.Name} command. {parameters.Length} {(parameters.Length > 1 ? "arguments" : "argument")} expected.");
                }
                return;
            }

            try
            {
                _method.DynamicInvoke(args);
            }
            catch (TargetInvocationException invocationEx)
            {
                _consoleHelper.WriteLineWithPrefix($"{invocationEx?.InnerException?.Message}");
            }
            catch (Exception ex) {
                _consoleHelper.WriteLineWithPrefix($"Unexpected error happened: {ex.Message}");
            }

            return;
        }

        public void Helper()
        {
            if (_method == null)
            {
                _consoleHelper.WriteLineWithPrefix("Method does not exist");
                return;
            }

            MethodInfo methodInfo = _method!.GetMethodInfo();
            ParameterInfo[] parameters = methodInfo.GetParameters();
            _consoleHelper.WriteLineWithPrefix($"{methodInfo.Name} method takes {parameters.Length} {(parameters.Length > 1 ? "arguments" : "argument")}");
            return;
        }
    }
}
