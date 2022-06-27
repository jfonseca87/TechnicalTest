using CapicuaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CapicuaAPI.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
