namespace Globo.Commands.Commands
{
    using Results;

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        IExecutionResult Execute();
    }
}