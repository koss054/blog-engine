namespace BlogEngine.API.Services
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Entities;
    using Models.User;
    using Services.Common.User;

    public class UserServices : IUserService
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> RegisterUser(RegisterUser registerUser)
        {
            if (await GetUser(registerUser) != null) return null;

            using var hmac = new HMACSHA512();

            var user = new User 
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password)),
                PasswordSalt = hmac.Key
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> LoginUser(LoginUser loginUser) {
            var user = await GetUser(loginUser);

            if (user is null) return null;

            if (loginUser.UserName.Contains("@")) 
                user.UserName = loginUser.Email;

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));

            for (int i = 0; i < computedHash.Length; i++) {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }

            return user;
        }

        private async Task<User?> GetUser(IUserDto user) {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.UserName == user.UserName || u.Email == user.Email);
        }
    }
}