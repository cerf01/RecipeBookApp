using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products;
using RecipeBookApp.DAL.Moduls;

namespace RecipeBookApp.DAL
{
    public class Context : DbContext
    {
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodDetails> FoodDetails { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeFood> RecipeFoods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(AppContext.BaseDirectory)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            var connectionStr = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Food>()
                .HasOne(f => f.Details)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RecipeFood>().HasKey(f => new { f.FoodId, f.RecipeId });

            modelBuilder.Entity<RecipeFood>()
               .HasOne(r => r.Recipe)
               .WithMany(f => f.RecipeFood)
               .HasForeignKey(f => f.RecipeId);


            modelBuilder.Entity<RecipeFood>()
              .HasOne(r => r.Food)
              .WithMany(f => f.RecipeFood)
              .HasForeignKey(f => f.FoodId);

        }

    }
}