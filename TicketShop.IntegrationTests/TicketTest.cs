using _181010_IS_Homework1;
using _181010_IS_Homework1.Repository;
using _181010_IS_Homework1.Services.Implementation;
using _181010_IS_Homework1.Services.Interface;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketShop.IntegrationTests.Data;
using Xunit;

namespace TicketShop.IntegrationTests
{
    // NOTE: Should POST actions be tested in integration testing?
    // NOTE: Working with PredefinedData
    public class TicketTest 
    {
        /*private readonly TestServer _server;*
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;

        public TicketTest(ApplicationDbContext context)
        {
            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationPath = Path.GetFullPath(Path.Combine(integrationTestsPath, "../../../../181010_IS_Homework1"));

            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseContentRoot(applicationPath)
                .UseEnvironment("Development"));
            _client = _server.CreateClient();

        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }

        [Fact]
        public async Task Index_Get_ReturnsIndexHtmlPage_ListingEveryTicket()
        {
            // Act
            var response = await _client.GetAsync("/Tickets");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            foreach (var ticket in _context.Tickets)
            { 
                Assert.Contains($"< h3 > { @ticket.Title} </ h3 >", responseString);
            }
        }*/



        [Fact]
        public async Task Index_Get_ReturnsIndexHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            foreach (var ticket in PredefinedData.Tickets)
            {
                Assert.Contains($"<h3>{@ticket.Title}</h3>", responseString);
            }
        }



        [Fact]
        public async Task Details_Get_ReturnsDetailsHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Details/40022a5e-1058-4f05-8fe3-0d8175388930");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains(PredefinedData.Tickets[0].Image, responseString);
        }



        [Fact]
        public async Task Details_Get_WhenItemDoesNotExist()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Details/40022a5e-1058-4f05-8fe3-0d817538893");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Empty(responseString);
        }



        [Fact]
        public async Task Create_Get_ReturnsCreateHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Create");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Create", responseString);
        }



        [Fact]
        public async Task Edit_Get_ReturnsCreateHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Edit/40022a5e-1058-4f05-8fe3-0d8175388930");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Edit", responseString);
        }



        [Fact]
        public async Task Edit_Get_WhenItemDoesNotExist()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Edit/");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("", responseString);
        }



        [Fact]
        public async Task AddToShoppingCart_Get_ReturnsCreateHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/AddToShoppingCart/40022a5e-1058-4f05-8fe3-0d8175388930");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Add Selected Ticket to Shopping Cart", responseString);
        }
        


        [Fact]
        public async Task Delete_Get_ReturnsCreateHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Delete/ef583888-1dc1-4ea5-8510-c1412595a249");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<h3>Are you sure you want to delete this?</h3>", responseString);
        }



        [Fact]
        public async Task Delete_Get_WhenIdIsNull()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Delete/");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("", responseString);
        }



        [Fact]
        public async Task Delete_Get_WhenTicketIsNull()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Delete/1234567890");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("", responseString);
        }


    }
}
