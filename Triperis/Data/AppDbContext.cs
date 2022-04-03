using Microsoft.EntityFrameworkCore;
using Triperis.Models;

namespace Triperis.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
