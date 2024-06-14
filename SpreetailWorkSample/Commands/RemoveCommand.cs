using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class RemoveCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public RemoveCommand(IMultiDictionaryService service) : base(service.Remove)
        {
            _multiDictionaryService = service;
        }

    }
}
