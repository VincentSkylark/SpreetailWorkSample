using Moq;
using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;

namespace SpreetailTestProject
{
    public class MultiDictionaryServiceTest
    {
        [Fact]
        public void MultiDictionaryService_IsSingleton()
        {
            var service1 = MultiDictionaryService.Instance;
            var service2 = MultiDictionaryService.Instance;

            Assert.True(ReferenceEquals(service1, service2));
        }

        [Fact]
        public void TestAddCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("Added"), Times.Once);

            service.Add("foo", "bar");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("ERROR, member already exists for key"), Times.Once);
        }

        [Fact]
        public void TestAllMembersCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");
            service.Add("foo", "baz");

            service.AllMembers();
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix(1, "bar"), Times.Once);
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix(2, "baz"), Times.Once);
        }

        [Fact]
        public void TestClearCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");
            service.Add("foo", "baz");

            service.Clear();
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("Cleared"), Times.Once);
        }

        [Fact]
        public void TestItemsCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");
            service.Add("foo", "baz");

            service.Items();
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix(1, "foo: bar"), Times.Once);
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix(2, "foo: baz"), Times.Once);
        }

        [Fact]
        public void TestKeyExistsCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");

            service.KeyExists("foo");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("true"), Times.Once);

            service.KeyExists("baz");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("false"), Times.Once);
        }

        [Fact]
        public void TestKeysCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Keys();
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("empty set"), Times.Once);

            service.Add("foo", "bar");
            service.Add("baz", "bar");

            service.Keys();
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix(1, "foo"), Times.Once);
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix(2, "baz"), Times.Once);
        }

        [Fact]
        public void TestMemberExistsCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");

            service.MemberExists("foo", "bar");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("true"), Times.Once);

            service.MemberExists("foo", "baz");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("false"), Times.Once);
        }

        [Fact]
        public void TestMembersCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");
            service.Add("foo", "baz");

            service.Members("foo");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix(1, "bar"), Times.Once);
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix(2, "baz"), Times.Once);

            service.Members("bar");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("ERROR, key does not exist."), Times.Once);
        }

        [Fact]
        public void TestRemoveAllCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");
            service.Add("foo", "baz");

            service.RemoveAll("foo");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("Removed"), Times.Once);

            service.RemoveAll("foo");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("ERROR, key does not exist."), Times.Once);
        }

        [Fact]
        public void TestRemoveCommand()
        {
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var service = new MultiDictionaryService(consoleHelperMock.Object);

            service.Add("foo", "bar");
            service.Add("foo", "baz");

            service.Remove("foo", "bar");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("Removed"), Times.Once);

            service.Remove("foo", "bar");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("ERROR, member does not exist."), Times.Once);

            service.Remove("baz", "bar");
            consoleHelperMock.Verify(c => c.WriteLineWithPrefix("ERROR, key does not exist."), Times.Once);
        }
    }
}
