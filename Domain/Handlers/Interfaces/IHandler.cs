using Domain.Commands.Interfaces;

namespace Domain.Handlers.Interfaces
{
    public interface IHandler<TCommand> where TCommand : ICommand
    {
        ICommandResult Handle(TCommand command);
    }
}
