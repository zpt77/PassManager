using Microsoft.EntityFrameworkCore;

namespace PassMenager.Logic.Model
{
    public class JippDBContext: DbContext
    {
        public DbSet<Passwords> Passwords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=JippDB;Integrated Security=True");
        }
    }
}
