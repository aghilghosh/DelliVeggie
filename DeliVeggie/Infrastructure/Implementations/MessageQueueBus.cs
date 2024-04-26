using DeliVeggiieShared;
using EasyNetQ;
using Microsoft.Extensions.Options;

namespace DeliVeggieGateway.Infrastructure.Implementations
{
    public class MessageQueueBus : IMessageQueueBus
    {
        private readonly IBus _messageBus;
        private readonly RabbitMqConfig _rabbitMqSettings;

        public MessageQueueBus(IOptions<RabbitMqConfig> rabbitMqSettings)
        {
            _rabbitMqSettings = rabbitMqSettings.Value;
            _messageBus = RabbitHutch.CreateBus(_rabbitMqSettings.ConnectionString);
        }

        public async Task<ProductDetailsResponse> GetProduct(string productId)
        {
            try
            {
                return await _messageBus.Rpc.RequestAsync<ProductDetailsRequest, ProductDetailsResponse>(new ProductDetailsRequest() { ProductId = productId });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProductsResponse> GetProducts()
        {
            try
            {
                return await _messageBus.Rpc.RequestAsync<ProductsRequest, ProductsResponse>(new ProductsRequest());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
