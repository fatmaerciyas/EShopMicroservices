using MediatR;

namespace BuildingBlocks.CQRS
{
    // Do not return any response
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> where TCommand : ICommand<Unit> { }

    // Return response object and it shouldn't be null
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse> where TResponse : notnull
    {
    }
}
