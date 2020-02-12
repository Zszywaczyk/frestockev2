using Microsoft.EntityFrameworkCore;
using StockData.Models;
using System;

namespace StockData
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
