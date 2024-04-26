using MongoDB.Driver;

namespace DeliVeggieProvider.Infrastructure.Abstraction
{
    public interface IDataContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
