using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class ClearCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public ClearCommand(IMultiDictionaryService service) : base(service.Clear)
        {
            _multiDictionaryService = service;
        }

    }
}