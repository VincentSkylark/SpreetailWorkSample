namespace SpreetailWorkSample.MultiDictionary
{
    public interface IMultiDictionaryService
    {
        void Add(string key, string value);
        void AllMembers();
        void Clear();
        void Items();
        void KeyExists(string key);
        void Keys();
        void MemberExists(string key, string member);
        void Members(string key);
        void RemoveAll(string key);
        void Remove(string key, string value);

    }
}
