using Microsoft.EntityFrameworkCore;
using TaskOne.Models;

namespace TaskOne.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) :base(option) 
        {

        }

        public DbSet<Article> Articles { get; set; }    
    }
}
