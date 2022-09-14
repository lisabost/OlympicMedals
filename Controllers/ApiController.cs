using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlympicMedals.Models;

namespace OlympicMedals.Controllers 
{
    [ApiController, Route("[controller]/country")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private DataContext _dataContext;

        public ApiController(ILogger<ApiController> logger, DataContext db)
        {
            _logger = logger;
            _dataContext = db;
        }

        [HttpGet]
        public IEnumerable<CountryMedals> GetAllCountries()
        {
            return _dataContext.CountryMedals;
        }

        [HttpGet("{id}")]
        public CountryMedals GetSingleCountry(int id)
        {
            return _dataContext.CountryMedals.Find(id);
        }

        [HttpPost]
        public CountryMedals AddCountry([FromBody] CountryMedals country) => _dataContext.AddCountry(new CountryMedals {
            Name = country.Name
        });

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
           CountryMedals wc = _dataContext.CountryMedals.Find(id);
            if (wc == null){
                return NotFound();
            }
            _dataContext.DeleteCountry(id);
            return NoContent();
        } 

    }

}