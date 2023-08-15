using ItemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }
    }
}
