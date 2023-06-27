using Asm02_KhanhHCE150703.Model;
using Microsoft.EntityFrameworkCore;

namespace Asm02_KhanhHCE150703.Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            : base(options)
        {
        }

        public DbSet<Asm02_KhanhHCE150703.Model.Movie> Movies { get; set; }
        public DbSet<Asm02_KhanhHCE150703.Model.MovieGenres> MovieGenres{ get; set; }
    }
}
