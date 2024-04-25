using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }
        }

        private List<Cheese> GetCheeses()
        {
            return
            [
                 new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = "$10.99/lb" },
                 new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and buttery", Strength = "Mild", Price = "$12.99/lb" },
                 new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty", Strength = "Medium", Price = "$9.99/lb" },
                 new Cheese { Name = "Blue Cheese", Type = "Semi-soft", Description = "Strong and pungent", Strength = "Strong", Price = "$14.99/lb" },
                 new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Mild", Price = "$8.99/lb" },
                 new Cheese { Name = "Camembert", Type = "Soft", Description = "Rich and earthy", Strength = "Medium", Price = "$13.99/lb" },
                 new Cheese { Name = "Parmesan", Type = "Hard", Description = "Nutty and granular", Strength = "Strong", Price = "$15.99/lb" },
                 new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky", Strength = "Mild", Price = "$7.99/lb" },
                 new Cheese { Name = "Swiss", Type = "Hard", Description = "Sweet and nutty", Strength = "Medium", Price = "$11.99/lb" },
                 new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Buttery and mild", Strength = "Mild", Price = "$10.49/lb" },
                 new Cheese { Name = "Gorgonzola", Type = "Semi-soft", Description = "Sharp and creamy", Strength = "Strong", Price = "$16.49/lb" },
                 new Cheese { Name = "Monterey Jack", Type = "Semi-soft", Description = "Mild and creamy", Strength = "Mild", Price = "$8.49/lb" },
                 new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Sharp and tangy", Strength = "Medium", Price = "$10.99/lb" },
                 new Cheese { Name = "Roquefort", Type = "Semi-soft", Description = "Intense and salty", Strength = "Strong", Price = "$17.99/lb" },
                 new Cheese { Name = "Gruyere", Type = "Hard", Description = "Rich and creamy", Strength = "Medium", Price = "$14.49/lb" },
                 new Cheese { Name = "Colby", Type = "Semi-hard", Description = "Mild and creamy", Strength = "Mild", Price = "$9.49/lb" },
                 new Cheese { Name = "Edam", Type = "Semi-hard", Description = "Smooth and mild", Strength = "Medium", Price = "$10.99/lb" },
                 new Cheese { Name = "Pepper Jack", Type = "Semi-soft", Description = "Spicy and creamy", Strength = "Medium", Price = "$9.99/lb" },
                 new Cheese { Name = "Muenster", Type = "Semi-soft", Description = "Mild and creamy", Strength = "Mild", Price = "$8.99/lb" },
                 new Cheese { Name = "Ricotta", Type = "Soft", Description = "Creamy and grainy", Strength = "Mild", Price = "$6.99/lb" }
            ];
        }

    }

}
