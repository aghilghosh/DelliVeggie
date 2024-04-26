using DeliVeggieProvider.Infrastructure.Abstraction;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DeliVeggieProvider.Infrastructure.Implementations
{
    public class DataContext : IDataContext
    {
        private IMongoDatabase _db { get; set; }
        private IMongoClient _client { get; set; }

        public DataContext(IOptions<DbConfig> config)
        {
            _client = new MongoClient(config.Value.ConnectionString);
            _db = _client.GetDatabase(config.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                return null;
            }
            return _db.GetCollection<T>(collectionName);
        }
    }
}