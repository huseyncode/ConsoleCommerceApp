﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants;

public enum AdminOperations
{
    Exit,
    GetAllSellers,
    GetAllCustomers,
    CreateSeller,
    CreateCustomer,
    DeleteSeller,
    DeleteCustomer,
    CreateCategory,
    OrdersByDesc,
    OrdersBySeller,
    OrdersByCustomer,
    GetOrdersByCreateDate

}

public enum CustomerOperatons
{
    Exit,
    BuyProduct,
    ShowBoughProducts,
    ShowOrderByDate,
    FilterProduct
}
public enum SellerOperations
{
    Exit,
    AddProduct,
    ChangeProductCount,
    DeleteProduct,
    ShowOrders,
    ShowOrderByDate,
    FilterProduct,
    GetTotalAmounts
}


