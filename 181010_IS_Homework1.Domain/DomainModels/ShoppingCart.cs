using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _181010_IS_Homework1.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public String ApplicationUserId { get; set; }
        public ICollection<TicketInShoppingCart> TicketsInShoppingCart { get; set; }

    }
}
