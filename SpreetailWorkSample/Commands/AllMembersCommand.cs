using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class AllMembersCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public AllMembersCommand(IMultiDictionaryService service) : base(service.AllMembers)
        {
            _multiDictionaryService = service;
        }

    }
}
