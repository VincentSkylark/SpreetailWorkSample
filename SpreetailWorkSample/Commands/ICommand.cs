namespace SpreetailWorkSample.Commands
{
    public interface ICommand
    {
        void Helper();
        void Execute(string?[] args);
    }
}
