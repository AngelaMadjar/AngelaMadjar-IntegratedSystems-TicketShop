using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.DTO;
using _181010_IS_Homework1.Repository.Interface;
using _181010_IS_Homework1.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _181010_IS_Homework1.Services.Implementation
{
    public class ShoppingCartService : IShoppingCart
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<TicketInOrder> _ticketInOrderRepository;
        private readonly IUserRepository _userRepository;

        //Dependency injection
        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository,
                                   IRepository<Order> orderRepository,
                                   IRepository<TicketInOrder> ticketInOrderRepository,
                                   IUserRepository userRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
            _userRepository = userRepository;
        }

        public bool deleteProductFromShoppingCart(string userId, Guid ticketId)
        {
            try
            {
                //getting the user
                var user = _userRepository.Get(userId);

                //getting the user's shopping cart
                var userShoppingCart = user.UserShoppingCart;

                //finding the ticket we want to delete
                var forRemoval = userShoppingCart.TicketsInShoppingCart.Where(z => z.TicketId == ticketId).FirstOrDefault();

                //deleting the ticket
                userShoppingCart.TicketsInShoppingCart.Remove(forRemoval);

                //updating user's shopping cart
                _shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public ShoppingCartDTO getShoppingCartInfo(string userId)
        {
            var user = _userRepository.Get(userId); //we can use this instead of the huge query
            /*var user = _context.Users.Where(z => z.Id == userId)
              .Include(z => z.UserShoppingCart) //the UserShoppingCart (of type ShoppingCart) is an attribute in the model ShopApplicationUser
              .Include("UserShoppingCart.TicketsInShoppingCart") //the TicketsInShoppingCart is a list (of type TicketInShoppingCart) in the model ShoppingCart
              .Include("UserShoppingCart.TicketsInShoppingCart.Ticket") //the Ticket is an attribute (of type Ticket) insite the TicketInShoppingCart model
              .FirstOrDefault();*/

            var userShoppingCart = user.UserShoppingCart;

            //selecting a custom set of variables (An anonymous json object)
            var ticketList = userShoppingCart.TicketsInShoppingCart.Select(z => new
            {
                Quantity = z.Quantity,
                TicketPrice = z.Ticket.Price
            }).ToList();

            //calculating the price
            float totalPrice = 0;
            foreach (var item in ticketList)
            {
                totalPrice += item.Quantity * item.TicketPrice;
            }

            //creating the object that has to be returned
            ShoppingCartDTO model = new ShoppingCartDTO
            {
                TotalPrice = totalPrice,
                TicketsInShoppingCart = userShoppingCart.TicketsInShoppingCart.ToList()
            };

            return model;
        }

        public void orderNow(string userId)
        {
            //getting the user
            var user = _userRepository.Get(userId);

            //getting user's shopping cart
            var userShoppingCart = user.UserShoppingCart;

            //creating the email message
            //EmailMessage message = new EmailMessage();
            //message.MailTo = user.Email;
            //message.Subject = "Successfully created order";
            //message.Status = false;

            //creating a new order for the user
            Order newOrder = new Order
            {
                UserId = user.Id,
                OrderedBy = user
            };

            //We first save the changes in the database and then pass the OrderId because of the incremental nature of the key (OrderId)
            _orderRepository.Insert(newOrder);

            List<TicketInOrder> ticketInOrder = userShoppingCart.TicketsInShoppingCart
                .Select(z => new TicketInOrder
                {
                    Ticket = z.Ticket,
                    TicketId = z.Ticket.Id,
                    Order = newOrder,
                    OrderId = newOrder.Id,
                    Quantity = z.Quantity
                }).ToList();

            //creating the content of the email message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Your order is completed. It contains: ");

            var totalPrice = 0.0;

            for (int i = 1; i <= ticketInOrder.Count(); i++)
            {
                var item = ticketInOrder[i - 1];
                totalPrice += item.Quantity * item.Ticket.Price;
                sb.AppendLine(i.ToString() + ". " + item.Ticket.Title + " with price: " + item.Ticket.Price + " and quantity: " + item.Quantity);
            }

            sb.AppendLine("Total price: " + totalPrice.ToString());

            //message.Content = sb.ToString();

            foreach (var item in ticketInOrder)
            {
                _ticketInOrderRepository.Insert(item);
            }

            //remove all items from the user's shopping cart
            user.UserShoppingCart.TicketsInShoppingCart.Clear();

            //inserting the newly created message
            //this._mailRepository.Insert(message);

            _userRepository.Update(user);
        }
    }
}
