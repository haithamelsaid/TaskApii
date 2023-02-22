using Microsoft.EntityFrameworkCore;

namespace TaskApi.Models
{
    public class MapDbContext:DbContext
    {
        public MapDbContext()
        {
            
        }
        public MapDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Map> Maps { get; set; }
        public DbSet<MapType> MapTypes { get; set; }
        public DbSet<MapSubType> MapSubTypes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
