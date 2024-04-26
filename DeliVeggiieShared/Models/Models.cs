
namespace DeliVeggiieShared
{
    public class Product : IProduct
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
    }

    public class ProductDetailsRequest
    {
        public string ProductId { get; set; }
    }

    public class ProductDetailsResponse
    {
        public Product Product { get; set; }
    }

    public class ProductsRequest
    {
    }

    public class ProductsResponse
    {
        public IEnumerable<Product> ProductList { get; set; }
    }
}
