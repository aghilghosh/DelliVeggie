namespace DeliVeggiieShared.Models
{
    public interface IResponse
    {
    }

    public class ProductDetailsResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double PriceWithReduction { get; set; }
    }

    public class Response<T> : IResponse
    {
        public T Data { get; set; }
    }
}