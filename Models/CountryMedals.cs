using System.ComponentModel.DataAnnotations;

namespace OlympicMedals
{
    public class CountryMedals
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }

    }
}