using Data.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public class SellerService:ISellerServices
    {
        private UnitOfWork _unitOfWork;

        public SellerService(UnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

        public void AddProduct()
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void OrderHistory()
        {
            throw new NotImplementedException();
        }

        public void OrderHistoryByDate()
        {
            throw new NotImplementedException();
        }

        public void OrderHistoryName()
        {
            throw new NotImplementedException();
        }

        public void TotalProfit()
        {
            throw new NotImplementedException();
        }

        public void UpdateProductStock()
        {
            throw new NotImplementedException();
        }
    }
}
