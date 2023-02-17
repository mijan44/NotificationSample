using Microsoft.EntityFrameworkCore;
using NotificationSample.Models;

namespace NotificationSample.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SupportRequest> SupportRequests { get; set; }

       

    }
}
