using SpreetailWorkSample.Commands;
using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailTestProject.MockCommands
{
    internal class MockCommand: ICommand
    {
        private readonly IMultiDictionaryService _service;


        public MockCommand(IMultiDictionaryService service)
        {
            _service = service;
        }
        public void Helper()
        {
            return;
        }

        public void Execute(string?[] args)
        {
            return;
        }
    }
}
