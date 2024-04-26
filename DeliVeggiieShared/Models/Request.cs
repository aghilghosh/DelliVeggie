namespace DeliVeggiieShared.Models
{
    public interface IRequest
    {
    }

    public class ProductDetailsRequest
    {
        public string ProductId { get; set; }
    }

    public class ProductsRequest
    {
    }

    public class Request<T> : IRequest
    {
        public T Data { get; set; }
    }
}