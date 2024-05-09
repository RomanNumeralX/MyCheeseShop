using MyCheeseShop.Model;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using MyCheeseShop.Components;
using MyCheeseShop.Model;
using MyCheeseShop.Context;
using Microsoft.AspNetCore.Components.Authorization;


namespace MyCheeseShop.Context
{
    public class UserProvider
    {
        private User user;

        private readonly DatabaseContext _context;

        public UserProvider(DatabaseContext context)
        {
            _context = context;
        }

        public User? GetUserByUsername(string? username)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }

    }
}
