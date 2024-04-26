using DeliVeggieProvider.Entities;
using DeliVeggieProvider.Infrastructure.Abstraction;
using DeliVeggiieShared.Abstraction;
using DeliVeggiieShared.Dto;
using MongoDB.Bson;
using MongoDB.Driver;

internal class InventoryRepository : IInventoryRepository
{
    private const string CollectionName = "Products";

    private IMongoCollection<ProductEntity> _products;

    public InventoryRepository(IDataContext dbContext)
    {
        _products = dbContext.GetCollection<ProductEntity>(CollectionName);
    }

    public async Task<List<ProductDto>> GetAllProductAsync()
    {
        var result = await _products.FindAsync(p => true).Result.ToListAsync();

        return result.Select(x => new ProductDto()
        {
            Id = x.Id.ToString(),
            Name = x.Name,
            EntryDate = x.EntryDate,
            Price = x.Price
        }).ToList() ?? new List<ProductDto>();
    }

    public async Task<ProductDto> GetProductAsync(string productId)
    {
        if (ObjectId.TryParse(productId, out ObjectId objectId))
        {
            var result = await _products.FindAsync(p => p.Id == objectId).Result.FirstOrDefaultAsync();
            if (result != null)
            {
                return new ProductDto
                {
                    Id = result.Id.ToString(),
                    Name = result.Name,
                    EntryDate = result.EntryDate,
                    Price = result.Price,

                    PriceReductions = result.PriceReductions.Select(x => new PriceReductionDto()
                    {
                        DayOfWeek = x.DayOfWeek,
                        Reduction = x.Reduction
                    }).ToList() ?? new List<PriceReductionDto>()
                };
            }
        }

        return null;
    }
}