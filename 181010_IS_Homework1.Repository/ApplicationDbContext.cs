using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace _181010_IS_Homework1.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Adding the models I want to include in the datbase
        //Each table will have as many columns as there are arguments in the model
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TicketInShoppingCart> TicketsInShoppingCart { get; set; }
        public virtual DbSet<ShopApplicationUser> ShopApplicationUsers { get; set; }
        public virtual DbSet<TicketInOrder> TicketsInOrder { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        //Creating a composite key for the TicketInShoppingCart (many2many relationship)
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TicketInShoppingCart>().HasKey(c => new { c.CartId, c.TicketId });
            builder.Entity<TicketInOrder>().HasKey(c => new { c.OrderId, c.TicketId });
        }
    }
}
