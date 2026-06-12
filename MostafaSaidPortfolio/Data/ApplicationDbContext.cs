using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MostafaSaidPortfolio.Models;

namespace MostafaSaidPortfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Project configuration
            builder.Entity<Project>().HasIndex(p => p.Title).IsUnique();

            // Project -> Category: optional FK
            builder.Entity<Project>()
                   .HasOne(p => p.Category)
                   .WithMany(c => c.Projects)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            // BlogPost -> Category: optional FK
            builder.Entity<BlogPost>()
                   .HasOne(b => b.Category)
                   .WithMany(c => c.BlogPosts)
                   .HasForeignKey(b => b.CategoryId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            // BlogPost -> Author (User): optional FK
            builder.Entity<BlogPost>()
                   .HasOne(b => b.Author)
                   .WithMany(u => u.BlogPosts)
                   .HasForeignKey(b => b.AuthorId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            // BlogPost -> Tags: many-to-many
            builder.Entity<BlogPost>()
                   .HasMany(b => b.Tags)
                   .WithMany(t => t.BlogPosts);

            // Comment -> BlogPost: optional FK
            builder.Entity<Comment>()
                   .HasOne(c => c.BlogPost)
                   .WithMany(b => b.Comments)
                   .HasForeignKey(c => c.BlogPostId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            // Comment -> Author (User): optional FK
            builder.Entity<Comment>()
                   .HasOne(c => c.Author)
                   .WithMany()
                   .HasForeignKey(c => c.AuthorId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            // Event configuration
            builder.Entity<Event>().Property(e => e.Date).IsRequired();
            builder.Entity<Event>().Property(e => e.EndDate).IsRequired();

            // Newsletter configuration
            builder.Entity<NewsletterSubscriber>().HasIndex(n => n.Email).IsUnique();

            // Testimonial configuration
            builder.Entity<Testimonial>()
                   .Property(t => t.Author)
                   .HasMaxLength(100)
                   .IsRequired();

            // ContactMessage configuration
            builder.Entity<ContactMessage>().Property(c => c.Email).IsRequired();
            builder.Entity<ContactMessage>().Property(c => c.Message).IsRequired().HasMaxLength(1000);

            // Category self-referencing
            builder.Entity<Category>()
                   .HasOne(c => c.ParentCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.ParentId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed initial data
            DataSeeder.Seed(builder);
        }
    }
}
