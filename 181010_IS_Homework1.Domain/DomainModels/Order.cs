using _181010_IS_Homework1.Domain.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace _181010_IS_Homework1.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ShopApplicationUser OrderedBy { get; set; }
        public List<TicketInOrder> Tickets { get; set; }
    }
}
