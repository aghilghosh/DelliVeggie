using DeliVeggieProvider.Infrastructure.Abstraction;
using DeliVeggiieShared.Abstraction;
using DeliVeggiieShared.Models;

namespace DeliVeggieProvider
{
    internal class ResponseHandler : IResponseHandler
    {
        private static IInventoryRepository _inventoryRepository;

        public ResponseHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IResponse> HandleRequest(IRequest arg)
        {
            if (arg is Request<ProductDetailsRequest> detailsRequest)
            {
                var details = Task.Run(async () =>
                {
                    return await _inventoryRepository.GetProductAsync(detailsRequest.Data.ProductId);
                }).GetAwaiter().GetResult();

                if (details == null)
                {
                    return new Response<ProductDetailsResponse>();
                }

                return new Response<ProductDetailsResponse>()
                {
                    Data = new ProductDetailsResponse()
                    {
                        Id = details.Id,
                        Name = details.Name,
                        EntryDate = details.EntryDate,
                        PriceWithReduction = ApplyPriceReduction(details, ((int)DateTime.Now.DayOfWeek) + 1)
                    }
                };
            }

            if (arg is Request<ProductsRequest> productsRequest) 
            {
                var details = await _inventoryRepository.GetAllProductAsync();

                if (details == null)
                {
                    return new Response<List<ProductDetailsResponse>>();
                }

                return new Response<List<ProductDetailsResponse>>()
                {
                    Data = details.Select(x => new ProductDetailsResponse()
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
                };
            }

            return null;
        }

        private double ApplyPriceReduction(ProductDto product, int dayOfWeek)
        {
            var priceReduction = product?.PriceReductions?.FirstOrDefault(x => Convert.ToInt16(x.DayOfWeek) == dayOfWeek);

            if (priceReduction == null)
            {
                return product.Price;
            }

            return product.Price * (1 - Convert.ToInt16(priceReduction.Reduction));
        }

    }
}
