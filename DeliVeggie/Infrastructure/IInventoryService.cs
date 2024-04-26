using DeliVeggiieShared;

namespace DeliVeggieGateway.Infrastructure
{
    public interface IInventoryService
    {
        Task<ProductsResponse> Products();

        Task<ProductDetailsResponse> Product(string productId);
    }
}
