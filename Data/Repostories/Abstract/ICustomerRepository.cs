using Core.Entities.UserEntities;
using Data.Repostories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Abstract
{
    public interface ICustomerRepository:IRepository<Customer>
    {
    }
}
