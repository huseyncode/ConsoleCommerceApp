using Core.Entities;
using Data.Contexts;
using Data.Repostories.Abstract;
using Data.Repostories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Concrete;

public class OrderRepository:Repository<Order>,IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context):base(context) 
    {
        _context = context;
    }
    public List<Order> GetOrderWithProductAndSellerAndCustomer()
    {
        return _context.Orders
            .Include(x => x.Product)
            .Include(s => s.Seller)
            .Include(c => c.Customer)
                .ToList();
    }

    public List<Order> GetOrderBySellerId(int id)
    {
        return _context.Orders
            .Include(x => x.Product)
            .Include(s => s.Seller)
            .Include(c => c.Customer)
            .Where(x => x.SellerId == id).ToList();
    }
    public List<Order> GetOrderByCustomerId(int id)
    {
        return _context.Orders
            .Include(x => x.Product)
            .Include(s => s.Seller)
            .Include(c => c.Customer)
            .Where(x => x.CustomerId == id).ToList();
    }
    public List<Order> GetOrdersByCreateDate(DateTime date)
    {
        return _context.Orders
            .Include(x => x.Product)
            .Include(s => s.Seller)
            .Include(c => c.Customer)
              .Where(x => x.CreatedAt.Date == date.Date).ToList();
    }
    public List<Order> GetOrdersBySellerCreateDate(DateTime date, int sellerid)
    {
        return _context.Orders
            .Include(x => x.Product)
            .Include(s => s.Seller)
            .Include(c => c.Customer)
            .Where(x => x.CreatedAt == date && x.SellerId == sellerid).ToList();
    }
    public List<Order> GetOrdersByCustomerCreateDate(DateTime date, int customerId)
    {
        return _context.Orders
            .Include(x => x.Product)
            .Include(s => s.Seller)
            .Include(c => c.Customer)
            .Where(x => x.CreatedAt == date && x.CustomerId == customerId).ToList();
    }
    public List<Order> GetOrdersByProductSymbol(string namesymbol, int customerId)
    {
        return _context.Orders
            .Include(s => s.Seller)
            .Include(s => s.Customer)
            .Include(s => s.Product)
            .Where(x => x.Product.Name.Contains(namesymbol) && x.CustomerId == customerId).ToList();
    }
}  
    


