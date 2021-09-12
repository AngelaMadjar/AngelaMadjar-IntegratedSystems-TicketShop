using _181010_IS_Homework1;
using _181010_IS_Homework1.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TicketShop.IntegrationTests
{
    public class HomeTest
    {
        /*private readonly TestServer _server;
        private readonly HttpClient _client;

        public HomeTest()
        {
            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationPath = Path.GetFullPath(Path.Combine(integrationTestsPath, "../../../../181010_IS_Homework1"));

            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>() //Once we use TestStartup instead of Startup, the integration test does not work (makes sense)
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
        public async Task Index_Get_ReturnsIndexHtmlPage()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("<title>Home Page - Integrated Systems</title>", responseString);
        }*/

        [Fact]
        public async Task Index_Get_ReturnsIndexHtmlPage()
        {
            // Arrange
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services
                    .AddDbContext<ApplicationDbContext>();
                })
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<Startup>();
                });

            // Create and start up the host
            var host = await builder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/Home");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<p>This is my first homework for the subject Integrated Systems :)</p>", responseString);
        }
    }
}
