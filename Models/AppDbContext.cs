using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using blog.Models;

namespace blog.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<GeneratedCode> GeneratedCodes { get; set; }
    }
}
