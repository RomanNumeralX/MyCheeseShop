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
                new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy, with a rich, mature flavor profile and a satisfyingly crumbly texture.", Strength = "Medium", Price = "£10.99" },
                new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and buttery, with a delicate, melt-in-your-mouth texture and a subtle hint of earthiness.", Strength = "Mild", Price = "£12.99", ImageUrl = $"..\\Components\\Cheese Images\\Brie.png"},
                new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty, boasting a subtle sweetness and a creamy texture with delightful caramel notes.", Strength = "Medium", Price = "£9.99" },
                new Cheese { Name = "Blue Cheese", Type = "Semi-soft", Description = "Strong and pungent, characterized by its distinctive blue veins and bold, complex flavor profile with a tangy finish.", Strength = "Strong", Price = "£14.99" },
                new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly, with a briny kick and a creamy texture that enhances salads and Mediterranean dishes.", Strength = "Mild", Price = "£8.99" },
                new Cheese { Name = "Camembert", Type = "Soft", Description = "Rich and earthy, with a velvety texture and a complex aroma that pairs perfectly with crusty bread and fruit.", Strength = "Medium", Price = "£13.99" },
                new Cheese { Name = "Parmesan", Type = "Hard", Description = "Nutty and granular, aged to perfection with a rich, savory taste and a crystalline texture that adds depth to any dish.", Strength = "Strong", Price = "£15.99" },
                new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky, known for its stretchy texture and delicate flavor that complements pizzas and Italian cuisine.", Strength = "Mild", Price = "£7.99" },
                new Cheese { Name = "Swiss", Type = "Hard", Description = "Sweet and nutty, with a slightly fruity aroma and iconic holes, perfect for melting atop sandwiches and burgers.", Strength = "Medium", Price = "£11.99" },
                new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Buttery and mild, with a creamy texture and subtle tanginess, ideal for snacking or melting in hot dishes.", Strength = "Mild", Price = "£10.49" },
                new Cheese { Name = "Gorgonzola", Type = "Semi-soft", Description = "Sharp and creamy, characterized by its intense flavor profile and luxurious, creamy texture with a spicy finish.", Strength = "Strong", Price = "£16.49" },
                new Cheese { Name = "Monterey Jack", Type = "Semi-soft", Description = "Mild and creamy, versatile and melt-in-your-mouth, perfect for adding a touch of richness to any dish.", Strength = "Mild", Price = "£8.49" },
                new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Sharp and tangy, with a distinctive flavor and smooth texture, ideal for sandwiches and cheese platters.", Strength = "Medium", Price = "£10.99" },
                new Cheese { Name = "Roquefort", Type = "Semi-soft", Description = "Intense and salty, with bold blue veining and a rich, creamy texture that leaves a lingering, savory taste.", Strength = "Strong", Price = "£17.99" },
                new Cheese { Name = "Gruyere", Type = "Hard", Description = "Rich and creamy, with a nutty flavor profile and a smooth, dense texture, perfect for fondue or gratins.", Strength = "Medium", Price = "£14.49" },
                new Cheese { Name = "Colby", Type = "Semi-hard", Description = "Mild and creamy, with a gentle flavor and smooth texture, ideal for snacking or melting in sandwiches.", Strength = "Mild", Price = "£9.49" },
                new Cheese { Name = "Edam", Type = "Semi-hard", Description = "Smooth and mild, boasting a mellow flavor and semi-firm texture, excellent for slicing or shredding.", Strength = "Medium", Price = "£10.99" },
                new Cheese { Name = "Pepper Jack", Type = "Semi-soft", Description = "Spicy and creamy, with a zesty kick and smooth texture, perfect for adding a flavorful punch to dishes.", Strength = "Medium", Price = "£9.99" },
                new Cheese { Name = "Muenster", Type = "Semi-soft", Description = "Mild and creamy, with a buttery texture and subtle tanginess, ideal for sandwiches or melting on burgers.", Strength = "Mild", Price = "£8.9b" },
                new Cheese { Name = "Ricotta", Type = "Soft", Description = "Creamy and grainy, with a delicate flavor and light, fluffy texture, perfect for both sweet and savory dishes.", Strength = "Mild", Price = "£6.99" }

            ];
        }

    }

}
