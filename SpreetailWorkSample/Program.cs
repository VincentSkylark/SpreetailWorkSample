using SpreetailWorkSample.Commands;
using SpreetailWorkSample.MultiDictionary;

namespace SpreetailWorkSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = MultiDictionaryService.Instance;

            var commands = new Dictionary<string, ICommand>
            {
                {"add", new AddCommand(service) },
                {"allmembers", new AllMembersCommand(service) },
                {"clear", new ClearCommand(service) },
                {"items", new ItemsCommand(service) },
                {"keyexists", new KeyExistsCommand(service) },
                {"keys", new KeysCommand(service) },
                {"memberexists", new MemberExistsCommand(service) },
                {"members", new MembersCommand(service) },
                {"removeall", new RemoveAllCommand(service) },
                {"remove", new RemoveCommand(service) }
            };

            var app = new App(commands);

            try
            {
                app.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
