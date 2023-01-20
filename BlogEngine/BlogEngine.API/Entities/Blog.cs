namespace BlogEngine.API.Entities
{
    public class Blog
    {
        public Blog()
        {
            this.Comments = new List<Comment>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public decimal Rating { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
