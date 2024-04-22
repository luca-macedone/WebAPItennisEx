using Microsoft.EntityFrameworkCore;
using WebAPItennisEx.Models;

namespace WebAPItennisEx
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base (options) {
        
        }

        public virtual DbSet<Player> Players { get; set; }
    }
}
