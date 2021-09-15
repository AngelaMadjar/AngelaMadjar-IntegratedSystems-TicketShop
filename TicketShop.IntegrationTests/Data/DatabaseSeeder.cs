using _181010_IS_Homework1.Domain.Identity;
using _181010_IS_Homework1.Repository;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TicketShop.IntegrationTests.Data
{
    // NOTE: We tried working with an InMemoryDatabase but unfortunately, this did not succeed. This was the part where we tried to seed the InMemoryDatabase with predefined data
    public class DatabaseSeeder 
    {
        private readonly UserManager<ShopApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DatabaseSeeder(ApplicationDbContext context, UserManager<ShopApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            // Add all the predefined profiles using the predefined password
            foreach (var profile in PredefinedData.Profiles)
            {
                await _userManager.CreateAsync(profile, PredefinedData.Password);
            }


            // Add all the predefined articles
            _context.Tickets.AddRange(PredefinedData.Tickets);
            _context.ShopApplicationUsers.AddRange(PredefinedData.Profiles);
            _context.SaveChanges();
        }
    }
}
