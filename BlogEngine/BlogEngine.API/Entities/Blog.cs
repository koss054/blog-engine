namespace BlogEngine.API.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Blog
    {
        public Blog()
        {
            Comments = new List<Comment>();
        }

        /// <summary>
        /// Id of blog.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Title of blog.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Content of blog.
        /// User has a text field where they can write and format their blog.
        /// </summary>
        [Required]
        [StringLength(10_000)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Rating of blog.
        /// Initially 0.
        /// After votes it changes.
        /// </summary>
        public decimal? Rating { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
