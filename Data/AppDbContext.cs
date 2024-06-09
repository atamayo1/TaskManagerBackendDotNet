// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using TaskManagerBackendDotNet.Models;
using Task = TaskManagerBackendDotNet.Models.Task;

namespace TaskManagerBackendDotNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí puedes configurar las relaciones entre entidades si es necesario
        }
    }
}
