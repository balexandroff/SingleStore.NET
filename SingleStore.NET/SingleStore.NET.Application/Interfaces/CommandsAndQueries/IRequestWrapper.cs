using SingleStore.NET.Application.Common;
using MediatR;

namespace SingleStore.NET.Application.Interfaces
{
    public interface IRequestWrapper<T> : IRequest<ServiceResult<T>>
    {

    }

    public interface IRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, ServiceResult<TOut>> where TIn : IRequestWrapper<TOut>
    {

    }
}
