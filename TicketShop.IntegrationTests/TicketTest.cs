using _181010_IS_Homework1;
using _181010_IS_Homework1.Domain.DomainModels;
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        /*private readonly TestServer _server;
        private readonly HttpClient _client;

        public TicketTest()
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

            Assert.Contains("Silk Road", responseString);

        }



        [Fact]
        public async Task Details_Get_ReturnsDetailsHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/Tickets/Details/{PredefinedData.Tickets[0].Id}");

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
            var response = await client.GetAsync($"/Tickets/Edit/{PredefinedData.Tickets[0].Id}");

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
            var response = await client.GetAsync($"/Tickets/AddToShoppingCart/{PredefinedData.Tickets[0].Id}");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Add Selected Ticket to Shopping Cart", responseString);
        }

       

        [Fact]
        public async Task Delete_Get_ReturnsDeleteHtmlPage()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/Tickets/Delete/{PredefinedData.Tickets[0].Id}");

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

        //EDIT POST

        [Fact]
        public async Task Edit_Post_EditTicket()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Tickets/Edit/1f85a895-65c6-488a-ba75-f2bec8706809");


            var formData = new Dictionary<string, string>
                   {
                   { "Id", "1f85a895-65c6-488a-ba75-f2bec8706809" },
                   { "Title", "/" },
                   { "Image", "/" },
                   {"Rating", "0" },
                   {"Price", "0"},
                   {"Seat", "0" },
                   {"DateAndTime", "DateTime.Now" },
                   {"TicketsInShoppingCart","null" }
                   };

            var response1 = await client.PostAsync("/Tickets/Edit/1f85a895-65c6-488a-ba75-f2bec8706809", new FormUrlEncodedContent(formData));


            // Assert
            var responseString = await response1.Content.ReadAsStringAsync();
            Assert.Equal(response1.StatusCode, HttpStatusCode.OK);
            Assert.Contains("DateTime.Now", responseString);
        }








        //delete

        //HTTP POST DELETE
        [Fact]
        public async Task Delete_Post_DeletesTicket()
        {
            // Arrange
            var factory = new WebApplicationFactory<Startup>();

            // Create an HttpClient which is setup for the test host
            var client = factory.CreateClient();
            // Arrange


            //fcee05a4-145f-41de-956b-f1e9f6cd25bb od databaza newdatabase -> dbo.Tickets
            var formData = PredefinedData.Tickets[1].Id.ToString();

            var gett = await client.GetAsync("Tickets/Delete/1f85a895-65c6-488a-ba75-f2bec8706809");

            // Act
            var response = await client.PostAsync("/Tickets/Delete/1f85a895-65c6-488a-ba75-f2bec8706809", new StringContent(formData));

            var responseString = await response.Content.ReadAsStringAsync();

            var responseAfterDeletion = await client.GetAsync("Tickets/Delete/1f85a895-65c6-488a-ba75-f2bec8706809");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, responseAfterDeletion.StatusCode);

        }



        

        //HTTP POST CREATE
        [Fact]
        public async Task Create_Post_CreatesNewTicket()
        {
            var factory = new WebApplicationFactory<Startup>();

            var clientOptions = new WebApplicationFactoryClientOptions();
            clientOptions.AllowAutoRedirect = true;
            clientOptions.BaseAddress = new Uri("http://localhost");
            clientOptions.HandleCookies = true;
            clientOptions.MaxAutomaticRedirections = 7;

            var client = factory.CreateClient(clientOptions);

            // await EnsureAuthenticationCookie();
            var formData = new Dictionary<string, string>
                   {
                   { "Id", "40022a5e-1058-4f05-8fe3-0d8175388932" },
                   { "Title", "nov" },
                   { "Image", "nova" },
                   {"Rating", "1" },
                   {"Price", "200"},
                   {"Seat", "4" },
                   {"DateAndTime", "DateTime.Now" },
                   {"TicketsInShoppingCart","null" }
                   };

            // Act
            var res = await client.GetAsync("/Tickets/Create");

            var response = await client.PostAsync("/Tickets/Create", new FormUrlEncodedContent(formData));

            var requestString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("nov", requestString);


        }

    }
}
