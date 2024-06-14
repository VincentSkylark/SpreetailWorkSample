using SpreetailWorkSample.MultiDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class AllMembersCommand : ICommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public AllMembersCommand(IMultiDictionaryService service)
        {
            _multiDictionaryService = service;
        }
        public void Execute(string?[] args) {
            if(args != null && args.Length > 0)
            {
                ConsoleUtility.InvalidArguments(0);
                return;
            }
            _multiDictionaryService.AllMembers();
        }
    }
}
