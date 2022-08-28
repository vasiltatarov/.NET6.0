namespace VerifyEmailForgotPasswordDemo.Data.Data
{
    using Microsoft.EntityFrameworkCore;
    using VerifyEmailForgotPasswordDemo.Data.Data.Models;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=.;Database=userdb;Trusted_Connection=true;");
        }

        public DbSet<User> Users => Set<User>();
    }
}
