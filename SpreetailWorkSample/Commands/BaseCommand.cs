using SpreetailWorkSample.Utility;
using System.Reflection;

namespace SpreetailWorkSample.Commands
{
    internal class BaseCommand : ICommand
    {
        private readonly Delegate _method;

        public BaseCommand(Delegate method)
        {
            _method = method;
        }
        public void Execute(string?[] args)
        {
            if (_method == null)
            {
                ConsoleUtility.WriteLineWithPrefix("Method does not exist");
                return;
            }

            MethodInfo methodInfo = _method!.GetMethodInfo();
            ParameterInfo[] parameters = methodInfo.GetParameters();

            if (args == null) args = Array.Empty<string>();

            if (parameters.Length != args.Length)
            {
                if (parameters.Length == 0)
                {
                    ConsoleUtility.WriteLineWithPrefix($"Invalid usage of {methodInfo.Name} command. No arguments expected.");
                }
                else
                {
                    ConsoleUtility.WriteLineWithPrefix($"Invalid usage of {methodInfo.Name} command. {parameters.Length} {(parameters.Length > 1 ? "arguments" : "argument")} expected.");
                }
                return;
            }

            try
            {
                _method.DynamicInvoke(args);
            }
            catch (Exception ex)
            {
                ConsoleUtility.WriteLineWithPrefix($"Unexpected error happened: {ex.Message}");
            }

            return;
        }
    }
}
