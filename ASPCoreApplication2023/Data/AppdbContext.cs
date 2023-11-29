using ASPCoreApplication2023.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023.Data
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<MembershipType> MembershipTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            string GenreJSon = System.IO.File.ReadAllText("Genres.Json");
            List<Genre>? genres = System.Text.Json.
            JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            //Seed to categorie
            foreach (Genre c in genres)
                model.Entity<Genre>()   
                .HasData(c);
        }
    }
}