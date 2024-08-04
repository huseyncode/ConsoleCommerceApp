using Core.Entities;
using Data.Repostories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Abstract
{
    public interface IOrderRepository:IRepository<Order>
    {
    }
}
