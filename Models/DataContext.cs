using Microsoft.EntityFrameworkCore;

namespace OlympicMedals 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<CountryMedals> CountryMedals { get; set; }
    }
}