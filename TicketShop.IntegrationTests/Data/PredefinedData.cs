using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketShop.IntegrationTests.Data
{
    public static class PredefinedData
    {
        public static string Password = @"!Covfefe123";

        public static ShopApplicationUser[] Profiles = new[] {
        new ShopApplicationUser { Name = "Angela", Surname = "Madjar", Address = "Address", Password = Password },
        new ShopApplicationUser { Name = "Petar", Surname = "Popovski", Address = "Address1", Password = Password }
    };

        public static Ticket[] Tickets = new[] {
        new Ticket { Id = Guid.Parse("40022a5e-1058-4f05-8fe3-0d8175388930"), Title = "Silk Road", Image = "https://image.tmdb.org/t/p/original/6KxiEWyIDpz1ikmD7nv3GTX4Uoj.jpg", Rating = 1, Price = 100, Seat = 2, DateAndTime = DateTime.Now, TicketsInShoppingCart = null},
        new Ticket { Id = Guid.Parse("1f85a895-65c6-488a-ba75-f2bec8706809"), Title = "Vanquish", Image = "https://m.media-amazon.com/images/M/MV5BZWEzZDdjMjAtOWM1Zi00MTZkLWE5OTEtMDg2YmNmODFjOTBjXkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_.jpg", Rating = 10, Price = 320, Seat = 5, DateAndTime = DateTime.Now, TicketsInShoppingCart = null}
    };
    }
}
