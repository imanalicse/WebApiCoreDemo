using Microsoft.EntityFrameworkCore;
using WebApiCoreDemo.Model;

namespace WebApiCoreDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<TicketItem> TicketItems { get; set; }
    }
}
