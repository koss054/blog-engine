namespace BlogEngine.API.Entities
{
    public class UserBlog
    {
        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public Guid BlogId { get; set; }

        public Blog Blog { get; set; } = null!;
    }
}
