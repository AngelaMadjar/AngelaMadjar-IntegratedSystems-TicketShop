using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _181010_IS_Homework1.Services.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetDetailsForTicket(Guid? id);
        void CreateNewTicket(Ticket t);
        void UpdateExistingTicket(Ticket t);
        AddToShoppingCartDTO GetShoppingCartInfo(Guid? id);
        void DeleteTicket(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDTO item, string userId);
    }
}
