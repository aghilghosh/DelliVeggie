using DeliVeggiieShared;

namespace DeliVeggieGateway.Infrastructure.Implementations
{
    public class InventoryService : IInventoryService
    {
        private readonly IMessageQueueBus _messageBus;
        public InventoryService(IMessageQueueBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task<ProductDetailsResponse> Product(string productId) => await _messageBus.GetProduct(productId);

        public async Task<ProductsResponse> Products() => await _messageBus.GetProducts();
    }
}
