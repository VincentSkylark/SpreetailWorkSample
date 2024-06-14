using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreetailWorkSample.Commands
{
    internal class RemoveCommand : ICommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public RemoveCommand(IMultiDictionaryService service)
        {
            _multiDictionaryService = service;
        }
        public void Execute(string?[] args) {
            if (args == null || args.Length != 2)
            {
                ConsoleUtility.InvalidArguments(2);
                return;
            }

            _multiDictionaryService.Remove(args[0]!, args[1]!);
        }

    }
}
