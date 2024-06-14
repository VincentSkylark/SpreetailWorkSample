using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class ItemsCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public ItemsCommand(IMultiDictionaryService service):base(service.Items)
        {
            _multiDictionaryService = service;
        }

    }
}
