using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("ERROR, member already exists for key");
                return;
            }
            if (!_dictionary.ContainsKey(key)) _dictionary[key] = new HashSet<string>();
            _dictionary[key].Add(value);
            Console.WriteLine("Added");
            return;
        }

        public void AllMembers()
        {
            if (_dictionary.Count == 0)
            {
                Console.WriteLine(") empty set");
                return;
            }

            int lineNumber = 0;
            foreach (string key in _dictionary.Keys)
            {
                foreach (string value in _dictionary[key])
                {
                    lineNumber++;
                    Console.WriteLine($"{lineNumber}) {value}");
                }
            }
            return;
        }

        public void Clear()
        {
            _dictionary.Clear();
            Console.WriteLine(") Cleared");
            return;
        }

        public void Items()
        {
            if (_dictionary.Count == 0)
            {
                Console.WriteLine(") empty set");
                return;
            }

            int lineNumber = 0;

            foreach (string key in _dictionary.Keys)
            {
                foreach (string value in _dictionary[key])
                {
                    lineNumber++;
                    Console.WriteLine($"{lineNumber}) {key}: {value}");
                }
            }
            return;
        }

        public void KeyExists(string key)
        {
            if (_dictionary.ContainsKey(key))
            {
                Console.WriteLine("true");
                return;
            }
            Console.WriteLine("false");
            return;

        }

        public void Keys()
        {
            if (_dictionary.Count == 0)
            {
                Console.WriteLine(") empty set");
                return;
            }

            int lineNumber = 0;

            foreach (string key in _dictionary.Keys)
            {
                lineNumber++;
                Console.WriteLine($"{lineNumber}) {key}");
            }
            return;
        }

        public void MemberExists(string key, string member)
        {
            if (!_dictionary.ContainsKey(key) || !_dictionary[key].Contains(member))
            {
                Console.WriteLine("false");
                return;
            }
            Console.WriteLine("true");
            return;
        }

        public void Members(string key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                Console.WriteLine(") ERROR, key does not exist.");
                return;
            }
            int lineNumber = 0;

            foreach (string member in _dictionary[key])
            {
                lineNumber++;
                Console.WriteLine($"{lineNumber}) {member}");
            }
            return;
        }

        public void RemoveAll(string key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                Console.WriteLine(") ERROR, key does not exist.");
                return;
            }

            _dictionary.Remove(key);
            Console.WriteLine(") Removed");
            return;
        }

        public void Remove(string key, string value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                Console.WriteLine(") ERROR, key does not exist.");
                return;
            }

            if (!_dictionary[key].Contains(value))
            {
                Console.WriteLine(") ERROR, member does not exist.");
                return;
            }

            _dictionary[key].Remove(value);
            if (_dictionary[key].Count == 0) _dictionary.Remove(key);
            Console.WriteLine(") Removed");
            return;

        }
    }
}
