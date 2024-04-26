using DeliVeggiieShared.Models;

namespace DeliVeggieProvider.Infrastructure.Abstraction
{
    public interface IResponseHandler
    {
        Task<IResponse> HandleRequest(IRequest arg);
    }
}
