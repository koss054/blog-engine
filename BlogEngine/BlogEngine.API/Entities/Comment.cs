namespace BlogEngine.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Content { get; set; } = null!;

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
