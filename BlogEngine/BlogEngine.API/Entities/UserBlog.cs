namespace BlogEngine.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserBlog
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public User User { get; set; } = null!;

        [ForeignKey(nameof(Blog))]
        public Guid BlogId { get; set; }

        [Required]
        public Blog Blog { get; set; } = null!;
    }
}
