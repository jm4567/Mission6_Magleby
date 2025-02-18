using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    // Database context for the "Movie Collection" app
    public class MovieCollectionContext : DbContext
    {
        // Constructor that accepts configuration options
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options) { }

        // Represents the "Movies" table in the database
        public DbSet<Movies> Movies { get; set; }
        
        public DbSet<Categories> Categories { get; set; }
    }
}