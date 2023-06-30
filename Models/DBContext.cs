using Microsoft.EntityFrameworkCore;

namespace norbit.crm.strashko.careertasks.backend.Models
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-GJTR0R0; Initial Catalog=norbit.crm.strashko.careertasks.database; TrustServerCertificate=True;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                CreatedOn= DateTime.Now,
                ModifiedOn= DateTime.Now,
                Name = "TestName1",
                Age = 0
            };

            modelBuider.Entity<User>().HasData(user);
        }
    }
}
