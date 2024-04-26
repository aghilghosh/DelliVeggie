using DeliVeggiieShared;

namespace DeliVeggieGateway.Infrastructure
{
    public interface IMessageQueueBus
    {
        Task<ProductDetailsResponse> GetProduct(string productId);
        Task<ProductsResponse> GetProducts();
    }
}
