using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeliVeggieProvider.Entities
{
    public class ProductEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }

        public IEnumerable<PriceReductionEntity> PriceReductions { get; set; }
    }
    public class PriceReductionEntity
    {
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}

