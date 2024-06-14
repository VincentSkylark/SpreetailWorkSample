using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class KeysCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public KeysCommand(IMultiDictionaryService service) : base(service.Keys)
        {
            _multiDictionaryService = service;
        }


    }
}
