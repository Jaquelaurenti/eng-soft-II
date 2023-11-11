public class Product : BaseEntity
{

    public int Amount { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public bool Cashback { get; set; }
    public bool Discount { get; set; }
    public Policy? Policy { get; set; }

}