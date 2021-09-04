using _181010_IS_Homework1.Domain.DomainModels;
using _181010_IS_Homework1.Domain.Identity;
using _181010_IS_Homework1.Repository.Interface;
using _181010_IS_Homework1.Services.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Services.xUnitTests.Moq
{
    public class OrderServiceTests
    {
        // sut = system under test
        private readonly OrderService _sut;

        // Mocking
        private readonly Mock<IOrderRepository> _orderRepoMock = new Mock<IOrderRepository>();

        // Initializing the instance of TicketService
        public OrderServiceTests()
        {
            _sut = new OrderService(_orderRepoMock.Object);
        }


        // TESTING: GetAllOrders()
        [Fact]
        public void getAllOrders()
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

            // Creating an order
            var order = new Order
            {
                UserId = userId,
                OrderedBy = user,
                Tickets = null
            };

            List<Order> orders = new List<Order>();
            orders.Add(order);

            // Mocking the created orders
            _orderRepoMock.Setup(x => x.GetAllOrders())
                .Returns(orders);

            // Act
            var resultList = _sut.GetAllOrders();
            var listSize = resultList.Count;

            // Assert
            Assert.Equal(1, listSize);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TESTING: GetOrderDetails(BaseEntity model)
        [Fact]
        public void GetOrderDetails()
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

            // Creating an order
            var order = new Order
            {
                UserId = userId,
                OrderedBy = user,
                Tickets = null
            };

            // Creating a base entity
            var model = new BaseEntity
            {
                Id = Guid.NewGuid()
            };

            // Mocking the created model
            _orderRepoMock.Setup(x => x.GetOrderDetails(model))
                .Returns(order);

            // Act
            var resultOrder = _sut.GetOrderDetails(model);

            // Assert
            Assert.Equal(userId, resultOrder.UserId);
            Assert.Equal(user, resultOrder.OrderedBy);
            Assert.Null(resultOrder.Tickets);
        }
    }
}