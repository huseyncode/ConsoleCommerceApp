namespace Core.Entities.UserEntities;

public class Seller:User
{
    public string PhoneNumber { get; set; }
    public string Pin { get; set; }
    public string SeriaNumber { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Order> Orders { get; set; }

}
