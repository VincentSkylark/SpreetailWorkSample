using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class AddCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;
        public AddCommand(IMultiDictionaryService service) : base(service.Add)
        {
            _multiDictionaryService = service;
        }

    }
}
