using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlympicMedals.Models;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet, SwaggerOperation(summary: "returns all countries, null")]
        public IEnumerable<CountryMedals> GetAllCountries()
        {
            return _dataContext.CountryMedals;
        }

        [HttpGet("{id}"), SwaggerOperation(summary: "returns specific country", null)]
        public CountryMedals GetSingleCountry(int id)
        {
            return _dataContext.CountryMedals.Find(id);
        }

        [HttpPost, SwaggerOperation(summary: "add country to collection", null), ProducesResponseType(typeof(CountryMedals), 201), SwaggerResponse(201, "Created")]
        public CountryMedals AddCountry([FromBody] CountryMedals country) => _dataContext.AddCountry(new CountryMedals {
            Name = country.Name
        });

        [HttpDelete("{id}"), SwaggerOperation(summary: "delete country from collection", null), ProducesResponseType(typeof(CountryMedals), 204), SwaggerResponse(204, "No Content")]
        public ActionResult Delete(int id){
           CountryMedals wc = _dataContext.CountryMedals.Find(id);
            if (wc == null){
                return NotFound();
            }
            _dataContext.DeleteCountry(id);
            return NoContent();
        } 
        
        [HttpPatch("{id")]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<CountryMedals> patch)
        {
            CountryMedals country = _dataContext.CountryMedals.Find(id);
            if(country != null)
            {
                return NotFound();
            }
            _dataContext.PatchCountry(id, patch);
            return NoContent();
        }
    }

}