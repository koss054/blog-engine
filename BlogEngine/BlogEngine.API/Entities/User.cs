namespace BlogEngine.API.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        /// <summary>
        /// Id of user.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Username of user.
        /// </summary>
        [Required]
        [StringLength(32)]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Email of user.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Password of user.
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Pass hash.
        /// </summary>
        public byte[] PasswordHash { get; set; } = null!;

        /// <summary>
        /// Pass salt.
        /// </summary>
        public byte[] PasswordSalt { get; set; } = null!;
    }
}
