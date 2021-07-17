using Microsoft.EntityFrameworkCore;
namespace seeker.Data
{
    public class DatabaseContext : DbContext{
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
        : base(options) {  
        }
        public DbSet<seeker.Models.Create> Creates {get; set;}
    }
}