using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;


namespace SpreetailWorkSample.Commands
{
    internal class RemoveAllCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public RemoveAllCommand(IMultiDictionaryService service) : base(service.RemoveAll)
        {
            _multiDictionaryService = service;
        }

    }
}
