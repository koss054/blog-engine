namespace BlogEngine.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        /// <summary>
        /// Id of comment.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Content of comment.
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Id of comment author.
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// Comment author.
        /// </summary>
        [Required]
        public User User { get; set; } = null!;

        /// <summary>
        /// Id of commented blog.
        /// </summary>
        [ForeignKey(nameof(Blog))]
        public Guid BlogId { get; set; }

        /// <summary>
        /// Blog with comment.
        /// </summary>
        [Required]
        public Blog Blog { get; set; } = null!;
    }
}
