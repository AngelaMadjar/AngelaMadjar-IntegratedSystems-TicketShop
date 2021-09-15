using _181010_IS_Homework1;
using _181010_IS_Homework1.Controllers;
using _181010_IS_Homework1.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TicketShop.IntegrationTests.Data;

namespace TicketShop.IntegrationTests
{
    // NOTE: We tried working with an InMemoryDatabase but unfortunately, this did not succeed
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        /*public override void ConfigureDatabase(IServiceCollection services)
        {
            // Replace default database connection with In-Memory database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("blogplayground_test_db"));

            // Register the database seeder
            services.AddTransient<DatabaseSeeder>();

        }

        public async override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Perform all the configuration in the base class
            base.Configure(app, env);


            // Now seed the database
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var seeder = serviceScope.ServiceProvider.GetService<DatabaseSeeder>();
                await seeder.Seed();
            }
        }*/
    }
}
