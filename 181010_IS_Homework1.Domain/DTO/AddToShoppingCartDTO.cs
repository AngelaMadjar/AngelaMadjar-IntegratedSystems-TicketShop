using _181010_IS_Homework1.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _181010_IS_Homework1.Domain.DTO
{
    public class AddToShoppingCartDTO
    {
        //Object only used to pass data from Model to View or from Model to Controller
        //Not saved in the database

        public Ticket SelectedTicket { get; set; }
        public Guid? TicketId { get; set; }
        public int Quantity { get; set; }
    }
}
