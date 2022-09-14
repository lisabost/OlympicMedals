using Microsoft.EntityFrameworkCore;

namespace OlympicMedals.Models 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<CountryMedals> CountryMedals { get; set; }
    }
}
