using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreetailWorkSample.Commands
{
    internal class MembersCommand : ICommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public MembersCommand(IMultiDictionaryService service)
        {
            _multiDictionaryService = service;
        }
        public void Execute(string?[] args) {
            if (args == null || args.Length != 1)
            {
                ConsoleUtility.InvalidArguments(1);
                return;
            }

            _multiDictionaryService.Members(args[0]!);
        }

    }
}
