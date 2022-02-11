namespace SuperHeroApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using SuperHeroApi.Models;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
