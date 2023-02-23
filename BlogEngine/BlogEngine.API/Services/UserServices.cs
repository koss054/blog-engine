namespace BlogEngine.API.Services
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;

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

        public async Task<User> RegisterUser(RegisterUser registerUser)
        {
            var user = new User();

            if (await UserExists(registerUser.UserName, registerUser.Email) == false)
            {
                using var hmac = new HMACSHA512();

                user.UserName = registerUser.UserName;
                user.Email = registerUser.Email;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password));
                user.PasswordSalt = hmac.Key;

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }

        public async Task<User?> LoginUser(LoginUser loginUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginUser.UserName);

            if (user != null)
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i]) return null;
                }
            }

            return user;
        }

        private async Task<bool> UserNameExists(string userName)
        {
            return await _context.Users
                .AnyAsync(u => u.UserName == userName);
        }

        private async Task<bool> UserExists(string userName, string email)
        {
            return await _context.Users
                .AnyAsync(u => u.UserName == userName || u.Email == email);
        }
    }
}