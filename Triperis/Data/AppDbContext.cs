using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Triperis.Models;

namespace Triperis.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
    //https://stackoverflow.com/questions/19902756/asp-net-identity-dbcontext-confusion
}
