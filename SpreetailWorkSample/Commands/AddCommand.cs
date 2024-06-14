using SpreetailWorkSample.MultiDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class AddCommand : ICommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;
        public AddCommand(IMultiDictionaryService service)
        {
            _multiDictionaryService = service;
        }
        public void Execute(string?[] args) {
            if (args == null || args.Length != 2) {
                ConsoleUtility.InvalidArguments(2);
                return;
            }

            _multiDictionaryService.Add(args[0]!, args[1]!);
        }

    }
}
