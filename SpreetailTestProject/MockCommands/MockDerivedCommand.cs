using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Commands;

namespace SpreetailTestProject.MockCommands
{
    internal class MockDerivedCommand : BaseCommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;
        public MockDerivedCommand(IMultiDictionaryService service) : base(service.Add)
        {
            _multiDictionaryService = service;
        }
    }
}
