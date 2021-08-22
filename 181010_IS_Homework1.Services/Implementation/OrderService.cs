using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Repository.Interface;
using _181010_IS_Homework1.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
           return _orderRepository.GetAllOrders();
        }

        public Order GetOrderDetails(BaseEntity model)
        {
            return this._orderRepository.GetOrderDetails(model);
        }
    }
}
