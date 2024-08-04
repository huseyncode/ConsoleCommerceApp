using Core.Entities;
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
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    { 
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Category GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
    
}
