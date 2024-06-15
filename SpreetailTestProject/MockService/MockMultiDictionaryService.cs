using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailTestProject.MockService
{
    internal class MockMultiDictionaryService : IMultiDictionaryService
    {
        private static readonly Lazy<MockMultiDictionaryService> _instance = new Lazy<MockMultiDictionaryService>(() => new MockMultiDictionaryService());
        public static MockMultiDictionaryService Instance => _instance.Value;


        public MockMultiDictionaryService()
        {
        }

        public void Add(string key, string value)
        {
            Console.WriteLine("MockMultiDictionaryService Add called");
        }

        public void AllMembers()
        {
            Console.WriteLine("MockMultiDictionaryService AllMembers called");
        }

        public void Clear()
        {
            Console.WriteLine("MockMultiDictionaryService Clear called");
        }

        public void Items()
        {
            Console.WriteLine("MockMultiDictionaryService Items called");
        }

        public void KeyExists(string key)
        {
            Console.WriteLine("MockMultiDictionaryService KeyExists called");
        }

        public void Keys()
        {
            Console.WriteLine("MockMultiDictionaryService Keys called");
        }

        public void MemberExists(string key, string member)
        {
            Console.WriteLine("MockMultiDictionaryService MemberExists called");
        }

        public void Members(string key)
        {
            Console.WriteLine("MockMultiDictionaryService Members called");
        }

        public void RemoveAll(string key)
        {
            Console.WriteLine("MockMultiDictionaryService RemoveAll called");
        }

        public void Remove(string key, string value)
        {
            Console.WriteLine("MockMultiDictionaryService Remove called");
        }

    }
}
