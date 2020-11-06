
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Art_gallery.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminLogin = "admin";
            string adminPassword = "123456";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Login = adminLogin, Password = adminPassword, RoleId = adminRole.Id };
            Tag tag1 = new Tag { Id = 1, Name = "Экспрессионизм", PostTags = new List<PostTag>()};
            Tag tag2 = new Tag { Id = 2, Name = "Модернизм", PostTags = new List<PostTag>() };
            Tag tag3 = new Tag { Id = 3, Name = "Реализм", PostTags = new List<PostTag>() };
            Tag tag4 = new Tag { Id = 4, Name = "Романтизм", PostTags = new List<PostTag>() };
            Tag tag5 = new Tag { Id = 5, Name = "Природа", PostTags = new List<PostTag>() };
            Tag tag6 = new Tag { Id = 6, Name = "Животные", PostTags = new List<PostTag>() };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            modelBuilder.Entity<Tag>().HasData(new Tag[] { tag1, tag2, tag3, tag4, tag5, tag6 });

            modelBuilder.Entity<PostTag>()
                .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(sc => sc.Post)
                .WithMany(s => s.PostTags)
                .HasForeignKey(sc => sc.PostId);

            modelBuilder.Entity<PostTag>()
                .HasOne(sc => sc.Tag)
                .WithMany(c => c.PostTags)
                .HasForeignKey(sc => sc.TagId);

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
                Database.EnsureCreated();
        }
    }
}
