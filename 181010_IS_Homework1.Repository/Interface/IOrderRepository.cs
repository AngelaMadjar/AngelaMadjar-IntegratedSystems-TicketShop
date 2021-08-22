using _181010_IS_Homework1.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(BaseEntity model);
    }
}
