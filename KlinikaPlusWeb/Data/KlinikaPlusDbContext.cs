using KlinikaPlusWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace KlinikaPlusWeb.Data
{
    public class KlinikaPlusDbContext : DbContext
    {
        public KlinikaPlusDbContext(DbContextOptions<KlinikaPlusDbContext> options) : base(options)
        {

        }

        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Ljekar> Ljekari { get; set; }
        public DbSet<Prijem> Prijemi { get; set; }
        public DbSet<Nalaz> Nalazi { get; set; }
    }
}
