using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.DTO;
using _181010_IS_Homework1.Domain.Identity;
using _181010_IS_Homework1.Repository.Interface;
using _181010_IS_Homework1.Services.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Services.xUnitTests.Moq
{


    // NOTE: I think it will be better to delete structures regarding e-mails, since we don't use nor test that functionality


    public class ShoppingCartServiceTests
    {
        // sut = system under test
        private readonly ShoppingCartService _sut;

        // Mocking 
        private readonly Mock<IRepository<ShoppingCart>> _shoppingCartRepoMock = new Mock<IRepository<ShoppingCart>>();
        private readonly Mock<IRepository<Order>> _orderRepoMock = new Mock<IRepository<Order>>();
        private readonly Mock<IRepository<TicketInOrder>> _ticketInOrderRepoMock = new Mock<IRepository<TicketInOrder>>();
        private readonly Mock<IUserRepository> _userRepoMock = new Mock<IUserRepository>();

        // Initializing the instance of TicketService
        public ShoppingCartServiceTests()
        {
            _sut = new ShoppingCartService(_shoppingCartRepoMock.Object, _orderRepoMock.Object,
                _ticketInOrderRepoMock.Object, _userRepoMock.Object);
        }


        // TESTING: deleteProductFromShoppingCart(string userId, Guid ticketId)
        [Fact]
        public void deleteProductFromShoppingCart_shouldReturnTrue_whenDelitingSuccessfully()
        {
            // Arrange

            // Creating a Ticket
            var ticketId = Guid.NewGuid();
            var title = "Example movie";
            var image = "someurl";
            var rating = 5;
            var price = 120;
            var seat = 2;
            var dateAndTime = DateTime.Now;

            var ticket = new Ticket
            {
                Id = ticketId,
                Title = title,
                Image = image,
                Rating = rating,
                Price = price,
                Seat = seat,
                DateAndTime = dateAndTime,
                TicketsInShoppingCart = null
            };

            // Creating a shopping cart
            var applicationUserId = "some-random-id";
            var cartId = Guid.NewGuid();
            var userShoppingCart = new ShoppingCart
            {
                ApplicationUserId = applicationUserId,
                Id = cartId,
                TicketsInShoppingCart = new List<TicketInShoppingCart>()
            };

            // Creating TicketInShoppingCart
            var ticketInShoppingCart = new TicketInShoppingCart
            {
                TicketId = ticketId,
                CartId = cartId,
                Ticket = ticket,
                ShoppingCart = userShoppingCart,
                Quantity = 1
            };

            // Creating a ShopApplicationUser
            var userId = "this-is-some-random-string-identifying-a-user";
            var name = "Angela";
            var surname = "Madjar";
            var address = "Address";
            var password = "Password";

            var user = new ShopApplicationUser
            {
                Id = userId,
                Name = name,
                Surname = surname,
                Address = address,
                Password = password,
                UserShoppingCart = userShoppingCart
            };

            // Mocking the created user
            _userRepoMock.Setup(x => x.Get(userId))
                .Returns(user);

            userShoppingCart.TicketsInShoppingCart.Add(ticketInShoppingCart);

            // Mocking the created shopping cart
            _shoppingCartRepoMock.Setup(x => x.Get(cartId))
                .Returns(userShoppingCart);

            // Act
            var result = _sut.deleteProductFromShoppingCart(userId, ticketId);


            // Assert
            Assert.True(result);
        }


        [Fact]
        public void deleteProductFromShoppingCart_shouldReturnFalce_whenDelitingUnsuccessfullyBecauseTheUserDoesNotExist()
        {
            // Arrange

            // Creating a Ticket
            var ticketId = Guid.NewGuid();
            var title = "Example movie";
            var image = "someurl";
            var rating = 5;
            var price = 120;
            var seat = 2;
            var dateAndTime = DateTime.Now;

            var ticket = new Ticket
            {
                Id = ticketId,
                Title = title,
                Image = image,
                Rating = rating,
                Price = price,
                Seat = seat,
                DateAndTime = dateAndTime,
                TicketsInShoppingCart = null
            };

            // Creating a shopping cart
            var applicationUserId = "some-random-id";
            var cartId = Guid.NewGuid();
            var userShoppingCart = new ShoppingCart
            {
                ApplicationUserId = applicationUserId,
                Id = cartId,
                TicketsInShoppingCart = new List<TicketInShoppingCart>()
            };

            // Creating TicketInShoppingCart
            var ticketInShoppingCart = new TicketInShoppingCart
            {
                TicketId = ticketId,
                CartId = cartId,
                Ticket = ticket,
                ShoppingCart = userShoppingCart,
                Quantity = 1
            };

            // Creating a ShopApplicationUser
            var userId = "this-is-some-random-string-identifying-a-user";
            var name = "Angela";
            var surname = "Madjar";
            var address = "Address";
            var password = "Password";

            var user = new ShopApplicationUser
            {
                Id = userId,
                Name = name,
                Surname = surname,
                Address = address,
                Password = password,
                UserShoppingCart = userShoppingCart
            };

            // user not registered exception! -> null reference exception (when attempting to get the user's shopping cart) -> entering the catch block

            userShoppingCart.TicketsInShoppingCart.Add(ticketInShoppingCart);

            // Mocking the created shopping cart
            _shoppingCartRepoMock.Setup(x => x.Get(cartId))
                .Returns(userShoppingCart);

            // Act
            var result = _sut.deleteProductFromShoppingCart(userId, ticketId);


            // Assert
            Assert.False(result);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: getShoppingCartInfo(string userId)
        [Fact]
        public void getShoppingCartInfo()
        {
            //Arrange

            // I need a user whose shopping cart I will access
            // Creating a ShopApplicationUser
            var userId = "this-is-some-random-string-identifying-a-user";
            var name = "Angela";
            var surname = "Madjar";
            var address = "Address";
            var password = "Password";
            var cartId = Guid.NewGuid(); // this will be a foreign key to the shopping cart, when creating a TicketInShoppingCart object
            var userShoppingCart = new ShoppingCart
            {
                Id = cartId,
                ApplicationUserId = "some-random-id",
                TicketsInShoppingCart = new List<TicketInShoppingCart>() // here, we initialize an empty list of TicketInShopingCart objects
            };

            var user = new ShopApplicationUser
            {
                Id = userId,
                Name = name,
                Surname = surname,
                Address = address,
                Password = password,
                UserShoppingCart = userShoppingCart
            };


            // Mocking the created user
            _userRepoMock.Setup(x => x.Get(userId))
                .Returns(user);

            // I need to create a ticket because it is an argument in the ticketInShoppingCart class
            // Creating a Ticket
            var ticketId = Guid.NewGuid();
            var title = "Example movie";
            var image = "someurl";
            var rating = 5;
            var price = 120;
            var seat = 2;
            var dateAndTime = DateTime.Now;

            var ticket = new Ticket
            {
                Id = ticketId,
                Title = title,
                Image = image,
                Rating = rating,
                Price = price,
                Seat = seat,
                DateAndTime = dateAndTime,
                TicketsInShoppingCart = null
            };

            // Creating an object of type ticketInShoppingCart
            var ticketInShoppingCart = new TicketInShoppingCart
            {
                TicketId = ticketId, // foreign key to the created ticket
                CartId = cartId, // foreign key to the created user's shopping cart
                Ticket = ticket, // the created ticket
                ShoppingCart = userShoppingCart, // the shopping cart
                Quantity = 5
            };

            // Adding the created ticketInShoppingCart in the user's shopping cart
            userShoppingCart.TicketsInShoppingCart.Add(ticketInShoppingCart);

            // Calculating the total price of the ticketsinshoppingcart  (should be 5*120 in this test)
            var ticketList = userShoppingCart.TicketsInShoppingCart.Select(z => new
            {
                Quantity = z.Quantity,
                TicketPrice = z.Ticket.Price
            });

            float totalPrice = 0;
            foreach (var item in ticketList)
            {
                totalPrice += item.Quantity * item.TicketPrice;
            }

            // Act
            var result = _sut.getShoppingCartInfo(userId);

            // Assert
            Assert.Equal(result.TotalPrice, totalPrice); // checking if the calculated total price is equal to the expected total price
            Assert.Equal(result.TicketsInShoppingCart.Count, userShoppingCart.TicketsInShoppingCart.Count); // checking the number of tickets in the user's shopping cart
            Assert.IsType<ShoppingCartDTO>(result); // checking if the function's return type is as expected
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: orderNow(string userId)
        // NOTE: This function containg the proccess of generating an email message but we don't want to test this
        [Fact]
        public void orderNow()
        {
            // Arrange

            // Creating a ShopApplicationUser
            var userId = "this-is-some-random-string-identifying-a-user";
            var name = "Angela";
            var surname = "Madjar";
            var address = "Address";
            var password = "Password";
            var cartId = Guid.NewGuid(); // this will be a foreign key to the shopping cart, when creating a TicketInShoppingCart object
            var userShoppingCart = new ShoppingCart
            {
                Id = cartId,
                ApplicationUserId = "some-random-id",
                TicketsInShoppingCart = new List<TicketInShoppingCart>() // here, we initialize an empty list of TicketInShopingCart objects
            };

            var user = new ShopApplicationUser
            {
                Id = userId,
                Name = name,
                Surname = surname,
                Address = address,
                Password = password,
                UserShoppingCart = userShoppingCart
            };


            // Mocking the created user
            _userRepoMock.Setup(x => x.Get(userId))
                .Returns(user);

            // I need to create a ticket because it is an argument in the ticketInShoppingCart class
            // Creating a Ticket
            var ticketId = Guid.NewGuid();
            var title = "Example movie";
            var image = "someurl";
            var rating = 5;
            var price = 120;
            var seat = 2;
            var dateAndTime = DateTime.Now;

            var ticket = new Ticket
            {
                Id = ticketId,
                Title = title,
                Image = image,
                Rating = rating,
                Price = price,
                Seat = seat,
                DateAndTime = dateAndTime,
                TicketsInShoppingCart = null
            };

            // Creating an object of type ticketInShoppingCart
            var ticketInShoppingCart = new TicketInShoppingCart
            {
                TicketId = ticketId, // foreign key to the created ticket
                CartId = cartId, // foreign key to the created user's shopping cart
                Ticket = ticket, // the created ticket
                ShoppingCart = userShoppingCart, // the shopping cart
                Quantity = 5
            };

            // Adding the created ticketInShoppingCart in the user's shopping cart
            userShoppingCart.TicketsInShoppingCart.Add(ticketInShoppingCart);


            // Act - Since the function is void, we are calling it in a try-catch block in order to check if it is executed
            try
            {
                _sut.orderNow(userId);

                // Assert
                Assert.Equal(0, user.UserShoppingCart.TicketsInShoppingCart.Count); // the shopping cart should be empty after calling this function
            }
            catch
            {
                // Assert
                Assert.True(false);
            }
        }
    }
}
