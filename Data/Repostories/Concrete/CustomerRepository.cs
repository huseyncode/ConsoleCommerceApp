using Core.Entities.UserEntities;
using Data.Contexts;
using Data.Repostories.Abstract;
using Data.Repostories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Concrete
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _context;


        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(x => x.Email == email);
        }


        public Customer GetCustomerByInput(string input)
        {
            return _context.Customers.FirstOrDefault(x => x.Email == input || x.Pin.ToLower() == input.ToLower() || x.SeriaNumber.ToLower() == input.ToLower()
            || x.PhoneNumber == input);
        }
    }
}

