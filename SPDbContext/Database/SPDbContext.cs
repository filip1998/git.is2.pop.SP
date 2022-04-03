using Microsoft.EntityFrameworkCore;
using Model.SP;

namespace SPDataContext.Database
{
    public class SPDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            => optionBuilder.UseNpgsql(@"Host=localhost;Port=5452;Database=SP;Username=postgres;Password=postgres");

        public SPDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Transport> Transport { get; set; }

    }
}
