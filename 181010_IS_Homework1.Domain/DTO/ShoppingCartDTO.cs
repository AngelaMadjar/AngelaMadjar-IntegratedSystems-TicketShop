using _181010_IS_Homework1.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _181010_IS_Homework1.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public float TotalPrice { get; set; }
        public List<TicketInShoppingCart> TicketsInShoppingCart{ get; set; }
    }
}
