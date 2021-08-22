using _181010_IS_Homework1.Domain.Identity;
using _181010_IS_Homework1.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _181010_IS_Homework1.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShopApplicationUser> entities;
        string ErrorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ShopApplicationUser>();
        }

        public IEnumerable<ShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public ShopApplicationUser Get(string id)
        {
            return entities
                .Include(z => z.UserShoppingCart) //the UserShoppingCart (of type ShoppingCart) is an attribute in the model ShopApplicationUser
                .Include("UserShoppingCart.TicketsInShoppingCart") //the TicketsInShoppingCart is a list (of type TicketInShoppingCart) in the model ShoppingCart
                .Include("UserShoppingCart.TicketsInShoppingCart.Ticket") //the Ticket is an attribute (of type Ticket) insite the TicketInShoppingCart model
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(ShopApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
