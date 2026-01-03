using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.domain;

namespace NZWalks.API.data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<difficulty> difficulties { get; set; }
        public DbSet<region> regions { get; set; }
        public DbSet<walk> walks { get; set; }
    }
}
