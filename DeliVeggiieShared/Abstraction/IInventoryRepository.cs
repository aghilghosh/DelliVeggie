namespace DeliVeggiieShared.Abstraction
{
    public interface IInventoryRepository
    {
        Task<List<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetProductAsync(string id);
    }
}
