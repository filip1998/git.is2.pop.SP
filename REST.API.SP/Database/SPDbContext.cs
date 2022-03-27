namespace REST.API.SP.Database
{
    public class SPDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            => optionBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=OP;Username=postgres;Password=postgres");

        public PDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public SbSet<Employees> Employees { get; set; }
        public SbSet<Departments> Departments { get; set; }
        public SbSet<Records> Records { get; set; }
        public SbSet<TypeOfHours> TypeOfHours { get; set; }
        public DbSet<WorkHourPrices> WorkHourPrices { get; set; }

    }
}
