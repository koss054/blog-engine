namespace BlogEngine.API.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(32)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(32)]
        public string Password { get; set; } = null!;
    }
}
