using Microsoft.EntityFrameworkCore;
using Task = ProxyService.Domain.Entities.Task;

namespace ProxyService.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)   
        {        }

    public DbSet<Task> Tasks { get; set; }
    }
}
