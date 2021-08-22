using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _181010_IS_Homework1.Domain.DomainModels
{
    public class TicketInOrder : BaseEntity
    {

        //Because Tickets2Order is a many-to-many relationship, I created this class

        [ForeignKey("TicketId")]
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
