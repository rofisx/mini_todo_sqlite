using Microsoft.EntityFrameworkCore;
using todoapi_sqllite.Models;

namespace todoapi_sqllite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
