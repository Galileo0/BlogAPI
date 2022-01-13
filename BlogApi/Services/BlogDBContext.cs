using Microsoft.EntityFrameworkCore;
using BlogApi.Models;
using System.Collections.Generic;

namespace BlogApi.Services
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options):base(options)
        {
            
        }

        public DbSet <BlogPost> BlogPosts { get; set; }
        public DbSet <Author> Authors { get; set; }
    }
}