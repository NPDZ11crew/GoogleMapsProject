using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoogleMaps_FinalProjectAspApi.DAL
{
    public class GMDbContext:DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<User> Users { get; set; }
        private string _dbConnectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GoogleMapsPlaces;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public GMDbContext(DbContextOptions<GMDbContext> options = null) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_dbConnectionString);
            }
        }
    }
}
