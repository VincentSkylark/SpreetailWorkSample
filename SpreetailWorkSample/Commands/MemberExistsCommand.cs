using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.Commands
{
    internal class MemberExistsCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public MemberExistsCommand(IMultiDictionaryService service) : base(service.MemberExists)
        {
            _multiDictionaryService = service;
        }

    }
}
