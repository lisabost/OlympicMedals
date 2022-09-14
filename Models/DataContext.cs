using Microsoft.EntityFrameworkCore;

namespace OlympicMedals.Models 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<CountryMedals> CountryMedals { get; set; }

        public CountryMedals AddCountry(CountryMedals country)
        {
            this.Add(country);
            this.SaveChanges();
            return country;
        }
    }
}
