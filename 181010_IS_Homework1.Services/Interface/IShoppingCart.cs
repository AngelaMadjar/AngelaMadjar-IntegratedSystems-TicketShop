using _181010_IS_Homework1.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Services.Interface
{
    public interface IShoppingCart
    {
        ShoppingCartDTO getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string userId, Guid ticketId);
        void orderNow(string userId);
    }
}
