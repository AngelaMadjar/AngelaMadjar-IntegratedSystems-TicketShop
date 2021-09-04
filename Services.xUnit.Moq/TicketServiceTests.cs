using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.DTO;
using _181010_IS_Homework1.Domain.Identity;
using _181010_IS_Homework1.Repository.Interface;
using _181010_IS_Homework1.Services.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Services.xUnitTests.Moq
{


    // NOTE: Check the validity of the tests intended for CRUD operations!


    public class TicketServiceTests
    {
        // sut = system under test
        private readonly TicketService _sut;

        // Mocking
        private readonly Mock<IRepository<Ticket>> _ticketRepoMock = new Mock<IRepository<Ticket>>();
        private readonly Mock<IRepository<TicketInShoppingCart>> _ticketInShoppingCartRepoMock = new Mock<IRepository<TicketInShoppingCart>>();
        private readonly Mock<IUserRepository> _userRepoMock = new Mock<IUserRepository>();

        // Initializing the instance of TicketService
        public TicketServiceTests()
        {
            _sut = new TicketService(_ticketRepoMock.Object, _ticketInShoppingCartRepoMock.Object, _userRepoMock.Object);
        }


        // TESTING: GetDetailsForTicket(Guid? id)
        [Fact]
        public void GetDetailsForTicket_ShouldReturnTicket_WhenTicketExists()
        {
            // Arrange
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

            _ticketRepoMock.Setup(x => x.Get(ticketId))
                .Returns(ticket);

            // Act
            var resultTicket = _sut.GetDetailsForTicket(ticketId);

            // Assert
            Assert.Equal(ticketId, resultTicket.Id);
            Assert.Equal(title, resultTicket.Title);
            Assert.Equal(image, resultTicket.Image);
            Assert.Equal(rating, resultTicket.Rating);
            Assert.Equal(price, resultTicket.Price);
            Assert.Equal(seat, resultTicket.Seat);
            Assert.Equal(dateAndTime, resultTicket.DateAndTime);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: AddToShoppingCart(AddToShoppingCartDTO item, string userId)
        [Fact]
        public void AddToShoppingCart_ShouldReturnTrue_WhenTicketAndUserShoppingCartExist()
        {
            // Arrange

            // Creating a ShopApplicationUser
            var userId = "this-is-some-random-string-identifying-a-user";
            var name = "Angela";
            var surname = "Madjar";
            var address = "Address";
            var password = "Password";
            var userShoppingCart = new ShoppingCart
            {
                ApplicationUserId = "some-random-id",
                TicketsInShoppingCart = null
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

            // Mocking the created ticket
            _ticketRepoMock.Setup(x => x.Get(ticketId))
                .Returns(ticket);

            // Creating the DTO
            var item = new AddToShoppingCartDTO
            {
                SelectedTicket = ticket,
                TicketId = ticketId,
                Quantity = 5
            };

            //Act
            var result = _sut.AddToShoppingCart(item, userId);

            //Assert
            Assert.True(result);
        }


        [Fact]
        public void AddToShoppingCart_ShouldReturnFalse_WhenTicketIdAndUserShoppingCartAreNull()
        {
            // Arrange

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
                UserShoppingCart = null // is null
            };

            // Mocking the created user
            _userRepoMock.Setup(x => x.Get(userId))
                .Returns(user);

            // Creating the DTO
            var item = new AddToShoppingCartDTO
            {
                SelectedTicket = null, // the value of the SelectedTicket is irrelevant for this case
                TicketId = null, // is null (In order to test this case, I changed the type Guid of TicketId to Guid? in the model AddToShoppingCartDTO)
                Quantity = 5
            };

            // Act
            var result = _sut.AddToShoppingCart(item, userId);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void AddToShoppingCart_ShouldReturnFalse_WhenUserShoppingCartIsNull()
        {
            // Arrange

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
                UserShoppingCart = null // is null
            };

            // Mocking the created user
            _userRepoMock.Setup(x => x.Get(userId))
                .Returns(user);

            // Creating the DTO
            var item = new AddToShoppingCartDTO
            {
                SelectedTicket = null, // the value of the SelectedTicket is irrelevant for this case
                TicketId = Guid.NewGuid(), // is not null
                Quantity = 5
            };

            // Act
            var result = _sut.AddToShoppingCart(item, userId);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void AddToShoppingCart_ShouldReturnFalse_WhenTicketIdIsNull()
        {
            // Arrange

            // Creating a ShopApplicationUser
            var userId = "this-is-some-random-string-identifying-a-user";
            var name = "Angela";
            var surname = "Madjar";
            var address = "Address";
            var password = "Password";
            var userShoppingCart = new ShoppingCart
            {
                ApplicationUserId = "some-random-id",
                TicketsInShoppingCart = null
            };

            var user = new ShopApplicationUser
            {
                Id = userId,
                Name = name,
                Surname = surname,
                Address = address,
                Password = password,
                UserShoppingCart = userShoppingCart // is not null
            };

            // Mocking the created user
            _userRepoMock.Setup(x => x.Get(userId))
                .Returns(user);

            // Creating the DTO
            var item = new AddToShoppingCartDTO
            {
                SelectedTicket = null, // the value of the SelectedTicket is irrelevant for this case
                TicketId = null, // is null
                Quantity = 5
            };

            // Act
            var result = _sut.AddToShoppingCart(item, userId);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void AddToShoppingCart_ShouldReturnFalse_WhenTicketIsNull()
        {
            // Arrange

            // Creating a ShopApplicationUser
            var userId = "this-is-some-random-string-identifying-a-user";
            var name = "Angela";
            var surname = "Madjar";
            var address = "Address";
            var password = "Password";
            var userShoppingCart = new ShoppingCart
            {
                ApplicationUserId = "some-random-id",
                TicketsInShoppingCart = null
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

            // Mocking any ticket
            _ticketRepoMock.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(() => null);

            // Creating the DTO
            var item = new AddToShoppingCartDTO
            {
                SelectedTicket = null, // is null
                TicketId = Guid.NewGuid(),
                Quantity = 5
            };

            // Act
            var result = _sut.AddToShoppingCart(item, userId);

            // Assert
            Assert.False(result);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: GetShoppingCartInfo(Guid? id)
        [Fact]
        public void GetShoppingCartInfo_ShouldReturnAddToShoppingCartDTO_WhenTicketExists()
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

            // Mocking the created ticket
            _ticketRepoMock.Setup(x => x.Get(ticketId))
                .Returns(ticket);

            // Act
            var result = _sut.GetShoppingCartInfo(ticketId);

            // Assert
            Assert.IsType<AddToShoppingCartDTO>(result);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: GetAllTickets()
        [Fact]
        public void GetAllTickets_ShouldReturnAListOfTickets_WhenTicketsExist()
        {
            // Arrange
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

            List<Ticket> tickets = new List<Ticket>();
            tickets.Add(ticket);

            _ticketRepoMock.Setup(x => x.GetAll())
                .Returns(tickets);

            // Act
            var resultList = _sut.GetAllTickets();

            // Assert
            Assert.Equal(tickets.Count, resultList.Count);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: CreateNewTicket(Ticket t)
        [Fact]
        public void CreateNewTicket_ShouldReturnTrue_WhenSuccessfullyAdded()
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

            // Act - Since the function is void, we are calling it in a try-catch block in order to check if it is executed
            try
            {
                _sut.CreateNewTicket(ticket);

                // Assert
                Assert.True(true);
            }
            catch
            {
                // Assert
                Assert.True(false);
            }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: DeleteTicket(Guid id)
        [Fact]
        public void DeleteTicket_ShouldReturnTrue_WhenSuccessfullyDeleted()
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

            _ticketRepoMock.Setup(x => x.Get(ticketId))
                .Returns(ticket);


            // Act
            try
            {
                _sut.DeleteTicket(ticketId);

                // Assert
                Assert.True(true);
            }
            catch
            {
                // Assert
                Assert.True(false);
            }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: UpdateExistingTicket(Ticket t)
        [Fact]
        public void UpdateExistingTicket_ShouldReturnTrue_WhenSuccessfullyUpdated()
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

            // Act
            try
            {
                _sut.UpdateExistingTicket(ticket);

                // Assert
                Assert.True(true);
            }
            catch
            {
                // Assert
                Assert.True(false);
            }
        }
    }
}
