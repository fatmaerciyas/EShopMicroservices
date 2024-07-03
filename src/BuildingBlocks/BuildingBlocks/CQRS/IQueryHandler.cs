using MediatR;

namespace BuildingBlocks.CQRS
{

    //get TQuery and return TReponse
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse> where TResponse : notnull
    {
    }
}
