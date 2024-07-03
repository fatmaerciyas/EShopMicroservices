using MediatR;

namespace BuildingBlocks.CQRS
{
    //Unit is representing void type for mediatR
    public interface ICommand : ICommand<Unit>
    {

    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
