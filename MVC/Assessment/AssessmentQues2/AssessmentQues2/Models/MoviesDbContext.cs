using System.Data.Entity;

namespace AssessmentQues2.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("MoviesDBConnection")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
