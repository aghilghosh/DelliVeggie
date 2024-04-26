namespace DeliVeggiieShared.Dto
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }

        public List<PriceReductionDto> PriceReductions { get; set; } = new List<PriceReductionDto>();
    }

    public class PriceReductionDto
    {
        public object DayOfWeek { get; set; }
        public object Reduction { get; set; }
    }
}


