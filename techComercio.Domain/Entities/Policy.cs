public class Policy : BaseEntity
{
    public TypePolicy Type { get; set; }
    public UserPerfil UserPerfil { get; set; }
    public bool ApplyDiscount { get; set; }
    public double ValueDiscount { get; set; }

}

public enum TypePolicy
{
    Cashback = 1,
    Discount = 2,
}