namespace BlogEngine.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserBlog
    {
        /// <summary>
        /// Id of user who is the blog author.
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// The blog author.
        /// </summary>
        [Required]
        public User User { get; set; } = null!;

        /// <summary>
        /// Id of the blog made by the user.
        /// </summary>
        [ForeignKey(nameof(Blog))]
        public Guid BlogId { get; set; }

        /// <summary>
        /// Blog written by the user.
        /// </summary>
        [Required]
        public Blog Blog { get; set; } = null!;
    }
}
