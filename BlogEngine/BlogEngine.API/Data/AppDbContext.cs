namespace BlogEngine.API.Data
{
    using Microsoft.EntityFrameworkCore;

    using Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserBlog>()
                .HasKey(ub => new { ub.UserId, ub.BlogId });

            base.OnModelCreating(builder);
        }

        public DbSet<Blog> Blogs { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<User> User { get; set; } = null!;

        public DbSet<UserBlog> UsersBlogs { get; set; } = null!;
    }
}
