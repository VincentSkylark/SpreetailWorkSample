using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.MultiDictionary
{
    public class MultiDictionaryService : IMultiDictionaryService
    {
        private static readonly Lazy<MultiDictionaryService> _instance = new Lazy<MultiDictionaryService>(() => new MultiDictionaryService());
        public static MultiDictionaryService Instance => _instance.Value;

        private Dictionary<string, HashSet<string>> _dictionary;

        public MultiDictionaryService()
        {
            _dictionary = new Dictionary<string, HashSet<string>>();
        }

        public void Add(string key, string value)
        {
            if (_dictionary.ContainsKey(key) && _dictionary[key].Contains(value))
            {
                ConsoleUtility.WriteLineWithPrefix("ERROR, member already exists for key");
                return;
            }
            if (!_dictionary.ContainsKey(key)) _dictionary[key] = new HashSet<string>();
            _dictionary[key].Add(value);
            ConsoleUtility.WriteLineWithPrefix("Added");
            return;
        }

        public void AllMembers()
        {
            if (_dictionary.Count == 0)
            {
                ConsoleUtility.WriteLineWithPrefix("empty set");
                return;
            }

            int lineNumber = 0;
            foreach (string key in _dictionary.Keys)
            {
                foreach (string value in _dictionary[key])
                {
                    lineNumber++;
                    ConsoleUtility.WriteLineWithPrefix(lineNumber, value);
                }
            }
            return;
        }

        public void Clear()
        {
            _dictionary.Clear();
            ConsoleUtility.WriteLineWithPrefix("Cleared");
            return;
        }

        public void Items()
        {
            if (_dictionary.Count == 0)
            {
                ConsoleUtility.WriteLineWithPrefix("empty set");
                return;
            }

            int lineNumber = 0;

            foreach (string key in _dictionary.Keys)
            {
                foreach (string value in _dictionary[key])
                {
                    lineNumber++;
                    ConsoleUtility.WriteLineWithPrefix(lineNumber, $"{key}: {value}");
                }
            }
            return;
        }

        public void KeyExists(string key)
        {
            if (_dictionary.ContainsKey(key))
            {
                ConsoleUtility.WriteLineWithPrefix("true");
                return;
            }
            ConsoleUtility.WriteLineWithPrefix("false");
            return;

        }

        public void Keys()
        {
            if (_dictionary.Count == 0)
            {
                ConsoleUtility.WriteLineWithPrefix("empty set");
                return;
            }

            int lineNumber = 0;

            foreach (string key in _dictionary.Keys)
            {
                lineNumber++;
                ConsoleUtility.WriteLineWithPrefix(lineNumber, $"{key}");
            }
            return;
        }

        public void MemberExists(string key, string member)
        {
            if (!_dictionary.ContainsKey(key) || !_dictionary[key].Contains(member))
            {
                ConsoleUtility.WriteLineWithPrefix("false");
                return;
            }
            ConsoleUtility.WriteLineWithPrefix("true");
            return;
        }

        public void Members(string key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                ConsoleUtility.WriteLineWithPrefix("ERROR, key does not exist.");
                return;
            }
            int lineNumber = 0;

            foreach (string member in _dictionary[key])
            {
                lineNumber++;
                ConsoleUtility.WriteLineWithPrefix(lineNumber, $"{member}");
            }
            return;
        }

        public void RemoveAll(string key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                ConsoleUtility.WriteLineWithPrefix("ERROR, key does not exist.");
                return;
            }

            _dictionary.Remove(key);
            ConsoleUtility.WriteLineWithPrefix("Removed");
            return;
        }

        public void Remove(string key, string value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                ConsoleUtility.WriteLineWithPrefix("ERROR, key does not exist.");
                return;
            }

            if (!_dictionary[key].Contains(value))
            {
                ConsoleUtility.WriteLineWithPrefix("ERROR, member does not exist.");
                return;
            }

            _dictionary[key].Remove(value);
            if (_dictionary[key].Count == 0) _dictionary.Remove(key);
            ConsoleUtility.WriteLineWithPrefix("Removed");
            return;

        }
    }
}
