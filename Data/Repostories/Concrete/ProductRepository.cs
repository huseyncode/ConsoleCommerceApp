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

public class ProductRepository:Repository<Product>,IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) : base(context) 
    {
        _context = context;
    }
    public List<Product> GetProductsBySellerId(int sellerId)
    {
        return _context.Products.Include(x => x.Seller).Where(x => x.SellerId == sellerId).ToList();
    }

    public List<Product> GetProductBySymbol(string namesymbol, int sellerId)
    {
        return _context.Products
            .Include(s => s.Seller)
            .Where(x => x.Name.Contains(namesymbol) && x.SellerId == sellerId).ToList();
    }
}


