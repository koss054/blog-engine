namespace BlogEngine.API.Services
{
    using System.Text;
    using System.Security.Claims;

    using Microsoft.IdentityModel.Tokens;

    using BlogEngine.API.Common;
    using BlogEngine.API.Entities;
    using Microsoft.IdentityModel.JsonWebTokens;
    using System.IdentityModel.Tokens.Jwt;

    public class TokenService : ITokenService
    {
        private SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>() 
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}