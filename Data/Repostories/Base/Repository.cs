﻿using Core.Entities.Base;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbTable;
        public Repository(AppDbContext context) 
        {
            _context = context;
            _dbTable = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbTable.ToList();   
        }
        public T Get(int id)
        {
             return _dbTable.Find(id);
        }

        public void Add(T item)
        {
            item.CreatedAt = DateTime.Now;
          _dbTable.Add(item);
        }

        public void Delete(T item)
        {
            _dbTable.Remove(item);
        }
        public void Update(T item)
        {
                        item.ModifiedAt = DateTime.Now;

            _dbTable.Update(item);
        }
        
    }
}
