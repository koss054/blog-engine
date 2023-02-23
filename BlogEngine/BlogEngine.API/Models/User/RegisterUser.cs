namespace BlogEngine.API.Models.User
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterUser
    {
        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 4)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(32, MinimumLength = 8)]
        public string Password { get; set; } = null!;
    }
}