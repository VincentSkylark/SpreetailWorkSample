using SpreetailTestProject.MockService;
using SpreetailTestProject.MockCommands;
using SpreetailWorkSample;
using SpreetailWorkSample.Commands;
using SpreetailWorkSample.Utility;
using Moq;

namespace SpreetailTestProject
{
    public class AppTests
    {
        [Fact]
        public void App_ShouldNotBeNull()
        {
            var service = MockMultiDictionaryService.Instance;
            var commands = new Dictionary<string, ICommand>
            {
                {"mock", new MockCommand(service) }
            };

            var consoleHelperMock = new Mock<IConsoleHelper>();

            var app = new App(commands, consoleHelperMock.Object);
            Assert.NotNull(app);

            var thread = new Thread(() => app.Run());

            var inputs = new Queue<string>(new[] { "mock", "wrong" });
            consoleHelperMock
            .Setup(ch => ch.ReadWithPrefix())
            .Returns(() => inputs.Count > 0 ? inputs.Dequeue() : "exit");

            thread.Start();
            Task.Delay(1000).Wait();
            consoleHelperMock.Verify(ch => ch.WriteLineWithPrefix(It.IsAny<string>()), Times.Exactly(2));
        }

        [Fact]
        public void App_ShouldExit()
        {
            var service = MockMultiDictionaryService.Instance;
            var commands = new Dictionary<string, ICommand>
            {
                {"mock", new MockCommand(service) }
            };

            var consoleHelperMock = new Mock<IConsoleHelper>();

            var app = new App(commands, consoleHelperMock.Object);

            var thread = new Thread(() => app.Run());

            consoleHelperMock
            .Setup(ch => ch.ReadWithPrefix())
            .Returns(() => "exit");

            thread.Start();
            Task.Delay(1000).Wait();
            consoleHelperMock.Verify(ch => ch.WriteLineWithPrefix("Exiting..."), Times.Once);
        }

        [Fact]
        public void Command_ShouldExecute()
        {
            var service = MockMultiDictionaryService.Instance;
            var commands = new Dictionary<string, ICommand>
            {
                {"add", new MockDerivedCommand(service) }
            };

            var consoleHelperMock = new Mock<IConsoleHelper>();

            var app = new App(commands, consoleHelperMock.Object);

            var thread = new Thread(() => app.Run());

            var inputs = new Queue<string>(new[] { "add foo bar", "add" });
            consoleHelperMock
            .Setup(ch => ch.ReadWithPrefix())
            .Returns(() => inputs.Count > 0 ? inputs.Dequeue() : "exit");

            using(var output = new StringWriter())
            {
                Console.SetOut(output);
                thread.Start();
                Task.Delay(1000).Wait();
                string[] lines = output.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                Assert.Contains("MockMultiDictionaryService Add called", lines[0]);
                Assert.Contains("Invalid usage of Add command. 2 arguments expected.", lines[1]);
            }
        }

    }
}