using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Context
{
    public class JustBlogContext : DbContext, IJustBlogContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }

        public JustBlogContext(DbContextOptions<JustBlogContext> options) :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You can config connection string for entity framework in here
            // optionsBuilder.UseSqlServer("Connection_string");
            base.OnConfiguring(optionsBuilder);
        }

        // Config fluent api in here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Config primary key
            modelBuilder.Entity<PostTagMap>().HasKey(pt=> new {pt.TagId,pt.PostId});

            // Config fluent api many tag to many PostTagMaps
            modelBuilder.Entity<PostTagMap>()
                .HasOne<Tag>(pt => pt.Tag)
                .WithMany(p => p.PostTagMaps)
                .HasForeignKey(p => p.TagId);

            // Config fluent api many post to many PostTagMaps
            modelBuilder.Entity<PostTagMap>()
                .HasOne<Post>(pt => pt.Post)
                .WithMany(p => p.PostTagMaps)
                .HasForeignKey(p => p.PostId);

            // Add seed data
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 1
            });
        }
        public override int SaveChanges() => base.SaveChanges();

        //Because it have different signatures so it can't overide
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync();
    }
}
