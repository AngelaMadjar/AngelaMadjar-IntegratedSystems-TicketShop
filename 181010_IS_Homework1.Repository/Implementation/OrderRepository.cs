using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }

        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z => z.OrderedBy)
                .Include(z => z.Tickets)
                .Include("Tickets.Ticket")
                .ToListAsync().Result;
        }

        public Order GetOrderDetails(BaseEntity model)
        {
            return entities
                .Include(z => z.OrderedBy)
                .Include(z => z.Tickets)
                .Include("Tickets.Ticket")
                .SingleOrDefaultAsync(z => z.Id == model.Id)
                .Result;
        }
    }
}
