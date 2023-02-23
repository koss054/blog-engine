namespace BlogEngine.API.Services
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common;
    using Entities;
    using Models.User;
    using System.Security.Cryptography;
    using System.Text;
    using BlogEngine.API.Data;
    using BlogEngine.API.Services.Common.User;

    public class UserServices : IUserService
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(RegisterUser registerUser)
        {
            if (await UserExists(registerUser)) return false;

            using var hmac = new HMACSHA512();

            var user = new User 
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                Password = registerUser.Password,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password)),
                PasswordSalt = hmac.Key
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<bool> UserExists(IUserDto user) {
            return await _context.Users.AnyAsync(u => u.UserName == user.UserName);
        }
    }
}