using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class MembersCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public MembersCommand(IMultiDictionaryService service) : base(service.Members)
        {
            _multiDictionaryService = service;
        }

    }
}
