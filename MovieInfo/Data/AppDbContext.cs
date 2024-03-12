using Microsoft.EntityFrameworkCore;
using MovieInfo.Models;

namespace MovieInfo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Director = "Chris Nolan", Review = 4 },
                new Movie { Id = 2, Title = "Dark Knight", Director = "Chris Nolan", Review = 5 },
                new Movie { Id = 3, Title = "Indiana Jones", Director = "Steven Spielberg", Review = 3 }
                );
        }
    }
}
