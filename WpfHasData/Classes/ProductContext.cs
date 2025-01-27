using Microsoft.EntityFrameworkCore;
using PayneServiceLibrary.Classes.Configuration;
using Serilog;
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
        /// <summary>
        /// Configures the model for the database context by defining the shape of entities, their relationships, and seeding initial data.
        /// </summary>
        /// <param name="modelBuilder">
        /// An instance of <see cref="ModelBuilder"/> used to configure the entity framework model.
        /// </param>
        /// <remarks>
        /// This method seeds initial data for the <see cref="Category"/> and <see cref="Product"/> entities
        /// if the <see cref="EntitySettings.Instance.CreateNew"/> property is set to <c>true</c>.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            if (!EntitySettings.Instance.CreateNew) return;

            Log.Information("Recreating data");

            modelBuilder.Entity<Category>().HasData(MockedData.Categories);
            modelBuilder.Entity<Product>().HasData(MockedData.Products);

            Log.Information("Done recreating data");

        }
    }
}
