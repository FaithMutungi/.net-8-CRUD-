using Microsoft.EntityFrameworkCore;
using SuperHeroWebApi.Net8.Entities;

namespace SuperHeroWebApi.Net8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<SuperHero> superHeroes { get; set; }

    }
}
