using Data.Contexts;
using Data.Repostories.Concrete;
using Data.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AdminRepository Admins;
        public readonly SellerRepository Sellers;
        public readonly CustomerRepository Customers;
        public readonly ProductRepository Products;
        public readonly CategoryRepository Categories;
        public readonly OrderRepository Orders;
        private readonly AppDbContext _context;
        public UnitOfWork()
        {
            _context = new AppDbContext();

            Admins = new AdminRepository(_context);
            Sellers = new SellerRepository(_context);
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Orders = new OrderRepository(_context);

        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
