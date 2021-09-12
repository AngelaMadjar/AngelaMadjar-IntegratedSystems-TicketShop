using _181010_IS_Homework1;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TicketShop.IntegrationTests
{
    // NOTE: In order to access the ShoppingCart, a user must be registered and logged in
    // I suppose that we should first call the action where the user gets registered (idk where this is)
    // And then call the ShoppingCart action
    public class ShoppingCartTest
    {
        [Fact]
        public async Task Index_Get_ReturnsIndexHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/ShoppingCart");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("Items in Shopping Cart", responseString);
        }
    }
}
