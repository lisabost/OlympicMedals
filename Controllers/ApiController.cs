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
    }

}