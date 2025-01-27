using Microsoft.EntityFrameworkCore;
using PayneServiceLibrary.Classes.Configuration;
using WpfHasData.Classes;

namespace WpfHasData
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DataConnections.Instance.MainConnection);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            if (!EntitySettings.Instance.CreateNew) return;

            modelBuilder.Entity<Category>().HasData(MockedData.Categories);
            modelBuilder.Entity<Product>().HasData(MockedData.Products);

        }
    }
}
