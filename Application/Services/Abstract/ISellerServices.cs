using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface ISellerServices
    {
        public void AddProduct();
        public void UpdateProductStock();
        public void DeleteProduct();
        public void OrderHistory();
        public void OrderHistoryByDate();
        public void OrderHistoryName();
        public void TotalProfit();

    }
}
