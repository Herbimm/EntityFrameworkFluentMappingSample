using EntityFrameworkFluentMappingSample.Data.Mappings;
using EntityFrameworkFluentMappingSample.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkFluentMappingSample.Data
{
    public class BlogDataContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        // public DbSet<PostTag> PostTags { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }


        public DbSet<PostWithTagsCount> PostWithTagsCount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=BlogWithEf;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;Encrypt=True");
            options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.Entity<PostWithTagsCount>(x =>
            x.ToSqlQuery(@"SELECT [Title] AS [Name], SELECT COUNT([Id]) FROM [Tags] Where [PostId] = [Id] AS [Count] FROM [Posts]")
            );

        }
    }
}
