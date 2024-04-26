namespace DeliVeggiieShared
{ 
    public interface IProduct
    {
        string Id { get; set; }
        string ProductName { get; set; }
        DateTime EntryDate { get; set; }
        double Price { get; set; }
    }
}
