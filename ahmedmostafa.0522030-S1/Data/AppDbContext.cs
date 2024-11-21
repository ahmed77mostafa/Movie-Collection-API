using ahmedmostafa._0522030_S1.Models;
using Microsoft.EntityFrameworkCore;

namespace ahmedmostafa._0522030_S1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
    }
}