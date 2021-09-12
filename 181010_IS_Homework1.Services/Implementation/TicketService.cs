using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.DTO;
using _181010_IS_Homework1.Repository.Interface;
using _181010_IS_Homework1.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _181010_IS_Homework1.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<TicketInShoppingCart> _ticketInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        public TicketService(IRepository<Ticket> ticketRepository, IRepository<TicketInShoppingCart> ticketInShoppingCartRepository, IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketInShoppingCartRepository = ticketInShoppingCartRepository;
            _userRepository = userRepository;
        }

        public TicketService() { }

        public bool AddToShoppingCart(AddToShoppingCartDTO item, string userId)
        {
            var user = this._userRepository.Get(userId);
            var userShoppingCart = user.UserShoppingCart;

            if(item.TicketId != null && userShoppingCart != null)
            {
                var ticket = this.GetDetailsForTicket(item.TicketId);
                
                if(ticket != null)
                {
                    TicketInShoppingCart itemToAdd = new TicketInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Ticket = ticket,
                        TicketId = ticket.Id,
                        ShoppingCart = userShoppingCart,
                        CartId = userShoppingCart.Id,
                        Quantity = item.Quantity
                    };
                    this._ticketInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
            /*//select 1 from Users where Id = userId
            //Include information about the user's shopping cart and the tickets inside it
            var user = await _context.Users.Where(z => z.Id == userId)
                .Include(z => z.UserShoppingCart) //the UserShoppingCart (of type ShoppingCart) is an attribute in the model ShopApplicationUser
                .Include("UserShoppingCart.TicketsInShoppingCart") //the TicketsInShoppingCart is a list (of type TicketInShoppingCart) in the model ShoppingCart
                .Include("UserShoppingCart.TicketsInShoppingCart.Ticket") //the Ticket is an attribute (of type Ticket) insite the TicketInShoppingCart model
                .FirstOrDefaultAsync();

            var userShoppingCart = user.UserShoppingCart;

            //need to check if user has a shopping cart in case he/she is not logged in
            if (userShoppingCart != null)
            {
                var ticket = _context.Tickets.Find(model.TicketId);
                if (ticket != null)
                {
                    TicketInShoppingCart itemToAdd = new TicketInShoppingCart
                    {
                        Ticket = ticket,
                        TicketId = ticket.TicketId,
                        ShoppingCart = userShoppingCart,
                        Quantity = model.Quantity
                    };
                    _context.Add(itemToAdd);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }*/
        }

        public void CreateNewTicket(Ticket t)
        {
            this._ticketRepository.Insert(t);
        }

        public void DeleteTicket(Guid id)
        {
            var ticket = this.GetDetailsForTicket(id);
            this._ticketRepository.Delete(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return this._ticketRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForTicket(Guid? id)
        {
            return this._ticketRepository.Get(id);
        }

        public AddToShoppingCartDTO GetShoppingCartInfo(Guid? id)
        {
            //SQL query: select 1 from Tickets where TicketId = ticketId
            //we use async when the query may need longer time to execute
            var ticket = this.GetDetailsForTicket(id);
            var model = new AddToShoppingCartDTO();
            model.SelectedTicket = ticket;
            model.TicketId = id.GetValueOrDefault();
            model.Quantity = 0;

            return model;
        }

        public void UpdateExistingTicket(Ticket t)
        {
            this._ticketRepository.Update(t);
        }
    }
}
