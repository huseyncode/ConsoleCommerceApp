using Core.Entities;
using Core.Entities.UserEntities;
using Data.Contexts;
using Data.Repostories.Abstract;
using Data.Repostories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Concrete
{
    public class SellerRepository:Repository<Seller>, ISellerRepository
    {
        private readonly AppDbContext _context;

        public SellerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Seller GetSellerWithEmailAndPassword(string email, string password)
        {
            return _context.Sellers.FirstOrDefault(x => x.Email == email && x.Password == password);
        }



        public Product GetExistProductWithNameAndSellerId(string name, int sellerId)
        {
            return _context.Products.Include(x => x.Seller).FirstOrDefault(x => x.Name.ToLower() == name.ToLower() && x.SellerId == sellerId);
        }

        public Seller GetSellerByEmail(string email)
        {
            return _context.Sellers.FirstOrDefault(x => x.Email == email);
        }
        public Seller GetSellerByInput(string input)
        {
            return _context.Sellers.FirstOrDefault(x => x.Email == input || x.Pin.ToLower() == input.ToLower() || x.SeriaNumber.ToLower() == input.ToLower()
            || x.PhoneNumber == input);
        }

    }
}

