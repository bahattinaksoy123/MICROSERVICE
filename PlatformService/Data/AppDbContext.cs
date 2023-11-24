using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            // Database.EnsureCreatedAsync();
        }
        public DbSet<Platform> Platforms {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("----> On Model Creating Running...");

            modelBuilder.Entity<Platform>().HasData(
                new() {
                        Id = 1,
                        Name = "Dot Net",
                        Publisher = "Microsoft",
                        Cost = "Free"
                },
                new() {
                    Id = 2,
                    Name = "Sql Server",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new() {
                    Id = 3,
                    Name = "Kubernetes",
                    Publisher = "Cloud Native Computeing Foundation",
                    Cost = "Free"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}