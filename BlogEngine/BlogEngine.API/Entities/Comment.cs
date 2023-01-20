namespace BlogEngine.API.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Content { get; set; } = null!;

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public Guid BlogId { get; set; }

        public Blog Blog { get; set; } = null!;
    }
}
