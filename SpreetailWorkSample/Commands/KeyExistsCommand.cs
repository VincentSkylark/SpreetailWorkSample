using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class KeyExistsCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public KeyExistsCommand(IMultiDictionaryService service) : base(service.KeyExists)
        {
            _multiDictionaryService = service;
        }

    }
}
