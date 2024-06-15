using SpreetailWorkSample.Utility;

namespace SpreetailWorkSample.MultiDictionary
{
    public class MultiDictionaryService : IMultiDictionaryService
    {
        private static readonly Lazy<MultiDictionaryService> _instance = new Lazy<MultiDictionaryService>(() => new MultiDictionaryService());
        public static MultiDictionaryService Instance => _instance.Value;

        private Dictionary<string, HashSet<string>> _dictionary;
        private readonly IConsoleHelper _consoleHelper;
        public MultiDictionaryService()
        {
            _dictionary = new Dictionary<string, HashSet<string>>();
            _consoleHelper = new ConsoleHelper();
        }

        public MultiDictionaryService(IConsoleHelper consoleHelper)
        {
            _dictionary = new Dictionary<string, HashSet<string>>();
            _consoleHelper = consoleHelper;
        }

        public void Add(string key, string value)
        {
            if (_dictionary.ContainsKey(key) && _dictionary[key].Contains(value))
            {
                _consoleHelper.WriteLineWithPrefix("ERROR, member already exists for key");
                return;
            }
            if (!_dictionary.ContainsKey(key)) _dictionary[key] = new HashSet<string>();
            _dictionary[key].Add(value);
            _consoleHelper.WriteLineWithPrefix("Added");
            return;
        }

        public void AllMembers()
        {
            if (_dictionary.Count == 0)
            {
                _consoleHelper.WriteLineWithPrefix(Constant.EMPTY_SET);
                return;
            }

            int lineNumber = 0;
            foreach (string key in _dictionary.Keys)
            {
                foreach (string value in _dictionary[key])
                {
                    lineNumber++;
                    _consoleHelper.WriteLineWithPrefix(lineNumber, value);
                }
            }
            return;
        }

        public void Clear()
        {
            _dictionary.Clear();
            _consoleHelper.WriteLineWithPrefix("Cleared");
            return;
        }

        public void Items()
        {
            if (_dictionary.Count == 0)
            {
                _consoleHelper.WriteLineWithPrefix(Constant.EMPTY_SET);
                return;
            }

            int lineNumber = 0;

            foreach (string key in _dictionary.Keys)
            {
                foreach (string value in _dictionary[key])
                {
                    lineNumber++;
                    _consoleHelper.WriteLineWithPrefix(lineNumber, $"{key}: {value}");
                }
            }
            return;
        }

        public void KeyExists(string key)
        {
            if (_dictionary.ContainsKey(key))
            {
                _consoleHelper.WriteLineWithPrefix("true");
                return;
            }
            _consoleHelper.WriteLineWithPrefix("false");
            return;

        }

        public void Keys()
        {
            if (_dictionary.Count == 0)
            {
                _consoleHelper.WriteLineWithPrefix(Constant.EMPTY_SET);
                return;
            }

            int lineNumber = 0;

            foreach (string key in _dictionary.Keys)
            {
                lineNumber++;
                _consoleHelper.WriteLineWithPrefix(lineNumber, $"{key}");
            }
            return;
        }

        public void MemberExists(string key, string member)
        {
            if (!_dictionary.ContainsKey(key) || !_dictionary[key].Contains(member))
            {
                _consoleHelper.WriteLineWithPrefix("false");
                return;
            }
            _consoleHelper.WriteLineWithPrefix("true");
            return;
        }

        public void Members(string key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _consoleHelper.WriteLineWithPrefix(Constant.KEY_NOT_EXIST);
                return;
            }
            int lineNumber = 0;

            foreach (string member in _dictionary[key])
            {
                lineNumber++;
                _consoleHelper.WriteLineWithPrefix(lineNumber, $"{member}");
            }
            return;
        }

        public void RemoveAll(string key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _consoleHelper.WriteLineWithPrefix(Constant.KEY_NOT_EXIST);
                return;
            }

            _dictionary.Remove(key);
            _consoleHelper.WriteLineWithPrefix("Removed");
            return;
        }

        public void Remove(string key, string value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _consoleHelper.WriteLineWithPrefix(Constant.KEY_NOT_EXIST);
                return;
            }

            if (!_dictionary[key].Contains(value))
            {
                _consoleHelper.WriteLineWithPrefix(Constant.MEMBER_NOT_EXIST);
                return;
            }

            _dictionary[key].Remove(value);
            if (_dictionary[key].Count == 0) _dictionary.Remove(key);
            _consoleHelper.WriteLineWithPrefix("Removed");
            return;

        }
    }
}
