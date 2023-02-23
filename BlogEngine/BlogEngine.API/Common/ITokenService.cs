namespace BlogEngine.API.Common
{
    using Entities;

    public interface ITokenService
    {
        public string CreateToken(User user);        
    }
}