using Core.Entities.Base;
using Core.Entities.UserEntities;
namespace Core.Entities;

public class Order: BaseEntity
{
    public decimal TotalAmount {  get; set; }
    public int Count { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public Product Product { get; set; }
    public int ProductId {  get; set; }
    public Seller Seller { get; set; }
    public int SellerId {get; set; }

}
