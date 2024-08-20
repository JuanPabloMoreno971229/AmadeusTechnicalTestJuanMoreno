using Microsoft.EntityFrameworkCore;

namespace AmadeusTechnicalTestJuanMoreno.Models
{
    public class passengerContex: DbContext
    {
        public passengerContex(DbContextOptions<passengerContex> options) :base(options)
        {
        }

        public DbSet<passenger> passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
